using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using System.Data.Entity;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Diagnostics;
using System.IO;
//using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using SmartReconciliator.ApplicationUtil;
using ApplicationSecurity;

namespace SmartReconciliator.Export
{
    public partial class FrmGenerateBill : Telerik.WinControls.UI.RadForm
    {
        ContractorManagementEntities dbContext = new ContractorManagementEntities();
        private List<ClientBillingInfoView> billingInformation;
        Excel.Application _excelApp;
        Excel.Workbooks _excelWorkbooks;
        Excel.Workbook _excelWorkbook;
        object _misValue = System.Reflection.Missing.Value;
        private List<CM_Config> _configDetails;
        private List<payPeriodDefinition> _payrollConfig;
        private List<CM_PayrollConfig> payrollConfigs;
        List<CM_BusinessLine> businessLines;
        List<RegionView> regionViews;

        public FrmGenerateBill()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmGenerateBill_Load(object sender, EventArgs e)
        {
            _payrollConfig = new List<payPeriodDefinition>();
            businessLines = new List<CM_BusinessLine>();
            regionViews = new List<RegionView>(); 
            int previousYear = DateTime.Now.Year - 1;
            payrollConfigs = dbContext.CM_PayrollConfig.Where(x => !x.Active).AsNoTracking().ToList();
            _configDetails = dbContext.CM_Config.ToList();
            businessLines = dbContext.CM_BusinessLine.Where(x => x.Active).AsNoTracking().ToList();
            regionViews = dbContext.RegionViews.AsNoTracking().ToList();

            foreach (CM_PayrollConfig config in payrollConfigs)
                _payrollConfig.Add(new payPeriodDefinition { payPeriodName = config.PayrollPeriod.ToString() + " - " + config.OpenDate.ToShortDateString() + " to " + config.CloseDate.ToShortDateString(), payPeriodNo = config.PayrollPeriod, payPeriodYear = config.PayrollYear });

            List<payPeriodDefinition> distinctPeriods = new List<payPeriodDefinition>();
            List<payPeriodDefinition> distinctYears = new List<payPeriodDefinition>();

            foreach(payPeriodDefinition definition in _payrollConfig)
            {
                bool periodExists = distinctPeriods.Where(x => x.payPeriodNo == definition.payPeriodNo).Any();

                if (!periodExists)
                    distinctPeriods.Add(definition);

                bool yearExists = distinctYears.Where(x => x.payPeriodYear == definition.payPeriodYear).Any();

                if (!yearExists)
                    distinctYears.Add(definition);
            }

            bindingSourcePeriod.DataSource = distinctPeriods.OrderBy(x=> x.payPeriodNo);
            bindingSourceYear.DataSource = distinctYears.OrderByDescending(x=> x.payPeriodYear);
            bindingSourceBusinessLine.DataSource = businessLines;
            bindingSourceRegion.DataSource = regionViews;

            ddlPeriod.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;
            ddlInvoiceOptions.SelectedIndex = 0;
            ddlBusinessLine.SelectedIndex = -1;
            ddlRegion.SelectedIndex = -1;

            this.ddlPeriod.DropDownListElement.AutoCompleteAppend.LimitToList = true;
            this.ddlYear.DropDownListElement.AutoCompleteAppend.LimitToList = true;
            this.ddlRegion.DropDownListElement.AutoCompleteAppend.LimitToList = true;
            this.ddlBusinessLine.DropDownListElement.AutoCompleteAppend.LimitToList = true;

            dtpStartDate.Value = DateTime.Today.Date;

            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (ddlPeriod.SelectedValue == null || ddlPeriod.SelectedIndex == -1)
            {
                if (rdBtnPayrollPeriod.IsChecked)
                {
                    RadMessageBox.Show("Select the Payroll period for which this invoice should be generated", System.Windows.Forms.Application.ProductName);
                    return;
                }
            }

            if (ddlYear.SelectedValue == null || ddlYear.SelectedIndex == -1)
            {
                if (rdBtnPayrollPeriod.IsChecked)
                {
                    RadMessageBox.Show("Select the Payroll year for which this invoice should be generated", System.Windows.Forms.Application.ProductName);
                    return;
                }
            }

            if (ddlBusinessLine.SelectedValue == null || ddlBusinessLine.SelectedIndex == -1)
            {
                RadMessageBox.Show("Select the business line for which this invoice should be generated", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (ddlRegion.SelectedValue == null || ddlRegion.SelectedIndex == -1)
            {
                RadMessageBox.Show("Select the region for which this invoice should be generated", System.Windows.Forms.Application.ProductName);
                return;
            }

            DialogResult ConfirmExport = RadMessageBox.Show("Are you sure you want to proceed with this export?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNo);

            if (ConfirmExport == DialogResult.Yes)
            {
                try
                {
                    FrmWaitDialogue _waitDialogue = new FrmWaitDialogue();
                    int payrollYear = rdBtnPayrollPeriod.IsChecked ? Convert.ToInt32(ddlYear.SelectedValue) : 0;
                    int payrollPeriod = rdBtnPayrollPeriod.IsChecked ? Convert.ToInt32(ddlPeriod.SelectedValue) : 0;
                    int businessLine = Convert.ToInt32(ddlBusinessLine.SelectedValue);
                    int region = Convert.ToInt32(ddlRegion.SelectedValue);

                    bool importExists = false;

                    if (rdBtnPayrollPeriod.IsChecked)
                    {
                        var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == payrollPeriod && x.PayrollYear == payrollYear).FirstOrDefault();

                        DateTime openDate = getPeriodDates.OpenDate;
                        DateTime closeDate = getPeriodDates.CloseDate;

                        importExists = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionImport.RegionId == region && x.TransactionImport.BusinessLineId == businessLine
                                        && x.TransactionDate >= openDate && x.TransactionDate <= closeDate).Any();
                    }
                    else
                    {
                        importExists = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionImport.RegionId == region && x.TransactionImport.BusinessLineId == businessLine
                                        && x.TransactionDate >= dtpStartDate.Value && x.TransactionDate <= dtpEndDate.Value).Any();
                    }

                    if (!importExists)
                    {
                        RadMessageBox.Show("Cannot find any imported transaction(s) for the selected period!", Application.ProductName);
                        return;
                    }

                    //bool isExportComplete = dbContext.ClientBillingInfoViews.Where(x => x.PayrollPeriod == payrollPeriod && x.PayrollYear == payrollYear.ToString() && x.IsBilled != null).Any();

                    //if (!isExportComplete)
                    //{
                    //    RadMessageBox.Show("Diaries are not yet exported for this period!", Application.ProductName);
                    //    return;
                    //}

                    string invoiceExportFolder = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Exported Invoices";

                    bool _dataBaseFolderExist = Directory.Exists(invoiceExportFolder);

                    if (!_dataBaseFolderExist)  
                        Directory.CreateDirectory(invoiceExportFolder);

                    int invoiceOptionId = ddlInvoiceOptions.SelectedIndex;
                         
                    List<object> bgwarguments = new List<object>(); 
                    bgwarguments.Add(payrollYear);
                    bgwarguments.Add(payrollPeriod);
                    bgwarguments.Add(invoiceExportFolder);
                    bgwarguments.Add(invoiceOptionId);
                    bgwarguments.Add(businessLine);
                    bgwarguments.Add(region);
                    bgwarguments.Add(dtpStartDate.Value);
                    bgwarguments.Add(dtpEndDate.Value);

                    if (BgwExport.IsBusy)
                    {
                        RadMessageBox.Show("System currently executing other processes.\n" +
                                           "This process cannot be executed at this time!", System.Windows.Forms.Application.ProductName);
                        return;
                    }

                    BgwExport.RunWorkerAsync(bgwarguments);
                    _waitDialogue.ShowDialog();
                }
                catch (Exception exp)
                {
                    RadMessageBox.Show(exp.InnerException == null ? exp.Message : exp.InnerException.Message);
                }
            }
        }

        private void BgwExport_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> _argumentList = e.Argument as List<object>;
            string payrollYear = _argumentList[0].ToString();
            int payrollPeriod = Convert.ToInt32(_argumentList[1]);
            string saveDestination = _argumentList[2].ToString();
            int invoiceOption = Convert.ToInt32(_argumentList[3]);
            int selectedBusinessLineId = Convert.ToInt32(_argumentList[4]);
            int selectedRegionId = Convert.ToInt32(_argumentList[5]);
            List<string> ticketNo = new List<string>();
            List<string> exemptedDescriptionList = new List<string>();
            billingInformation = new List<ClientBillingInfoView>();
            List<CM_ClientCode> exemptedCodes = new List<CM_ClientCode>();
            DateTime startDate = Convert.ToDateTime(_argumentList[6]);
            DateTime endDate = Convert.ToDateTime(_argumentList[7]);

            exemptedCodes = dbContext.CM_ClientCode.Where(x => x.ExcludeFromBill).AsNoTracking().ToList();

            foreach (CM_ClientCode code in exemptedCodes)
                exemptedDescriptionList.Add(code.Description);

            //int integerPayrollYear = Convert.ToInt32(payrollYear);
            //var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == payrollPeriod && x.PayrollYear == integerPayrollYear).FirstOrDefault();

            //DateTime openDate;// = getPeriodDates == null ? null : getPeriodDates.OpenDate;
            //DateTime closeDate;// = getPeriodDates.CloseDate;
                        
            if (invoiceOption == 0 || invoiceOption == 2)
            {
                List<ImportedTransactionsView> importedTransactions = new List<ImportedTransactionsView>();

                if (rdBtnPayrollPeriod.IsChecked)
                {
                    int integerPayrollYear = Convert.ToInt32(payrollYear);
                    var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == payrollPeriod && x.PayrollYear == integerPayrollYear).FirstOrDefault();

                    DateTime openDate = getPeriodDates.OpenDate;
                    DateTime closeDate = getPeriodDates.CloseDate;

                    importedTransactions = dbContext.ImportedTransactionsViews.Where(x => x.TransactionDate >= openDate && x.TransactionDate <= closeDate
                                           && x.RegionId == selectedRegionId && x.BusinessLineId == selectedBusinessLineId).AsNoTracking().ToList();
                }
                else
                    importedTransactions = dbContext.ImportedTransactionsViews.Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate
                                           && x.RegionId == selectedRegionId && x.BusinessLineId == selectedBusinessLineId).AsNoTracking().ToList();

                foreach (ImportedTransactionsView import in importedTransactions)
                    ticketNo.Add(import.JobNumber.Trim().ToUpper());
            }

            if (rdBtnPayrollPeriod.IsChecked)
                billingInformation = dbContext.ClientBillingInfoViews.Where(c => c.PayrollYear == payrollYear && c.PayrollPeriod == payrollPeriod
                                     && c.LeadContractor == 1 && c.BusinessLineId == selectedBusinessLineId && c.RegionId == selectedRegionId)
                                     .AsNoTracking().ToList();
            else
            {
                dbContext.Database.CommandTimeout = 600;

                billingInformation = dbContext.ClientBillingInfoViews.Where(c => c.JobDate >= startDate && c.JobDate <= endDate
                                     && c.LeadContractor == 1 && c.BusinessLineId == selectedBusinessLineId && c.RegionId == selectedRegionId)
                                     .AsNoTracking().ToList();
            }

            if (invoiceOption == 0)
                billingInformation = billingInformation.Where(x => ticketNo.Contains(x.TicketNo)).OrderBy(x => x.TicketNo).ToList();
            else if (invoiceOption == 2)
            {
                foreach (string number in ticketNo)
                {
                    var noExist = billingInformation.Where(x => x.TicketNo.Trim().Equals(number)).ToList();

                    if (noExist.Count > 0)
                    {
                        foreach(var no in noExist)
                            billingInformation.Remove(no);
                    }
                }

                billingInformation = billingInformation.OrderBy(x => x.TicketNo).ToList();
            }
            else
                billingInformation = billingInformation.OrderBy(x => x.TicketNo).ToList();            

            billingInformation = billingInformation.Where(x => !exemptedDescriptionList.Contains(x.ClientCodeDescription)).ToList();

            var getDistinctRegions = billingInformation.Select(x => x.RegionId).Distinct().ToList();

            foreach (var regionId in getDistinctRegions)
            {                
                int newRegionId = regionId;
                var clientSubSet = billingInformation.Where(x => x.RegionId == newRegionId).ToList();

                var getDistinctDiarys = clientSubSet.Select(x => x.DiaryTemplateId).Distinct().ToList();

                foreach (var diaryId in getDistinctDiarys)
                {
                    var getDiaryInfo = dbContext.CM_DiaryTemplate.Where(x => x.DiaryTemplateId == diaryId).FirstOrDefault();

                    _excelApp = new Microsoft.Office.Interop.Excel.Application();
                    string _applicationFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                    string _defaultFolderPath = _applicationFolderPath + "FlowDiaryTemplates";
                    string _diaryFileName = _defaultFolderPath + "\\" + getDiaryInfo.Description.Trim();
                    string diary = getDiaryInfo.Description.Trim();

                    _excelWorkbooks = _excelApp.Workbooks;

                    _excelWorkbook = _excelWorkbooks.Open(_diaryFileName, _misValue, _misValue, _misValue, _misValue,
                                     _misValue, _misValue, _misValue, _misValue, _misValue, _misValue, _misValue,
                                     _misValue, _misValue, _misValue);

                    Excel.Worksheet _myExcelWorksheet = (Excel.Worksheet)_excelWorkbook.ActiveSheet;
                    int _startRow = 12;
                    _excelApp.ScreenUpdating = false;

                    string _invoiceNo = string.Empty;

                    var _jobInformation = clientSubSet.Where(x => x.DiaryTemplateId == diaryId).ToList();

                    if (!_configDetails[0].BillingExportOrder.Trim().Equals("TicketNo"))
                        _jobInformation = _jobInformation.OrderBy(x => x.Contractor).ThenBy(x => x.JobDate).ToList();

                    //Added for the handling of invoice numbers and region name
                    //int _businessLineId = _jobInformation[0].BusinessLineId;
                    //int _invoiceNoRow = 5;
                    //int _regionRow = 7;
                    //_invoiceNo = BuildInvoiceNo(_businessLineId);


                    //if (diary.Trim() == "REHAB" || diary.Trim() == "PBX Install" || diary.Trim() == "IPTV Installation" || diary.Trim() == "PBX Install")
                    //{
                    //    _myExcelWorksheet.get_Range("E" + _invoiceNoRow.ToString(), _misValue).Formula = _invoiceNo;
                    //    _myExcelWorksheet.get_Range("E" + _regionRow.ToString(), _misValue).Formula = ddlRegion.Text.Trim();
                    //}
                    //else
                    //{
                    //    _myExcelWorksheet.get_Range("D" + _invoiceNoRow.ToString(), _misValue).Formula = _invoiceNo;
                    //    _myExcelWorksheet.get_Range("D" + _regionRow.ToString(), _misValue).Formula = ddlRegion.Text.Trim();
                    //}
                    //invoice numbers handling and region name ends here 

                    bool _clientCodeFound = false;
                    //int count = 0;

                    foreach (var _job in _jobInformation)
                    {
                        _startRow++;
                        _clientCodeFound = false;

                        _myExcelWorksheet.get_Range("A" + _startRow.ToString(), _misValue).Formula = _job.JobDate.ToString("MM/dd/yyyy");
                        _myExcelWorksheet.get_Range("B" + _startRow.ToString(), _misValue).Formula = _job.Contractor.Trim();
                        _myExcelWorksheet.get_Range("C" + _startRow.ToString(), _misValue).Formula = _job.TicketNo.Trim();

                        if (diary.Trim() == "PBX Install")
                        {
                            _myExcelWorksheet.get_Range("D" + _startRow.ToString(), _misValue).Formula = string.Empty;
                            _myExcelWorksheet.get_Range("E" + _startRow.ToString(), _misValue).Formula = _job.TelephoneNo.Trim().Replace("-", "").Replace("_", "");
                            _myExcelWorksheet.get_Range("F" + _startRow.ToString(), _misValue).Formula = _job.SiteAddress.Trim();
                            _myExcelWorksheet.get_Range("H" + _startRow.ToString(), _misValue).Formula = _job.JobDescription.Trim();
                        }
                        else if (diary.Trim() == "REHAB")
                        {
                            _myExcelWorksheet.get_Range("D" + _startRow.ToString(), _misValue).Formula = _job.TicketNo.Trim();
                            _myExcelWorksheet.get_Range("E" + _startRow.ToString(), _misValue).Formula = _job.TelephoneNo.Trim().Replace("-", "").Replace("_", "");
                            _myExcelWorksheet.get_Range("F" + _startRow.ToString(), _misValue).Formula = _job.SiteAddress.Trim();
                            _myExcelWorksheet.get_Range("H" + _startRow.ToString(), _misValue).Formula = _job.JobDescription.Trim();
                        }
                        else if (diary.Trim() == "IPTV Installation")
                        {
                            _myExcelWorksheet.get_Range("D" + _startRow.ToString(), _misValue).Formula = string.Empty;
                            _myExcelWorksheet.get_Range("E" + _startRow.ToString(), _misValue).Formula = _job.TelephoneNo.Trim().Replace("-", "").Replace("_", "");
                            _myExcelWorksheet.get_Range("F" + _startRow.ToString(), _misValue).Formula = _job.SiteAddress.Trim();
                            _myExcelWorksheet.get_Range("H" + _startRow.ToString(), _misValue).Formula = _job.JobDescription.Trim();
                        }
                        else if (diary.Trim() == "HFC Install and Repairs" || diary.Trim() == "HFC Install and Repairs ND" || diary.Trim() == "HFC Install and Repairs SRVC")
                        {
                            _myExcelWorksheet.get_Range("D" + _startRow.ToString(), _misValue).Formula = _job.ServiceOrderNo.Trim();//string.Empty;
                            _myExcelWorksheet.get_Range("E" + _startRow.ToString(), _misValue).Formula = _job.CustomerName.Trim();
                            _myExcelWorksheet.get_Range("F" + _startRow.ToString(), _misValue).Formula = _job.SiteAddress.Trim();
                            _myExcelWorksheet.get_Range("H" + _startRow.ToString(), _misValue).Formula = _job.JobDescription.Trim();
                            _myExcelWorksheet.get_Range("M" + _startRow.ToString(), _misValue).Formula = _job.Service.TrimStart('-');
                            _myExcelWorksheet.get_Range("AG" + _startRow.ToString(), _misValue).Formula = _job.QA100;
                            _myExcelWorksheet.get_Range("AH" + _startRow.ToString(), _misValue).Formula = _job.WRK;
                            _myExcelWorksheet.get_Range("AI" + _startRow.ToString(), _misValue).Formula = _job.RG6M;
                            _myExcelWorksheet.get_Range("AJ" + _startRow.ToString(), _misValue).Formula = _job.RG6l;
                            _myExcelWorksheet.get_Range("AK" + _startRow.ToString(), _misValue).Formula = _job.RG11;
                            _myExcelWorksheet.get_Range("AL" + _startRow.ToString(), _misValue).Formula = _job.AMPS;
                            _myExcelWorksheet.get_Range("AM" + _startRow.ToString(), _misValue).Formula = _job.SPLIT;
                        }
                        else
                        {
                            _myExcelWorksheet.get_Range("D" + _startRow.ToString(), _misValue).Formula = _job.TelephoneNo.Trim().Replace("-", "").Replace("_", "");
                            _myExcelWorksheet.get_Range("E" + _startRow.ToString(), _misValue).Formula = _job.SiteAddress.Trim();
                            _myExcelWorksheet.get_Range("G" + _startRow.ToString(), _misValue).Formula = _job.JobDescription.Trim();
                        }

                        string _cellInfo = string.Empty;

                        if (diary.Trim() != "HFC Install and Repairs" || diary.Trim() == "HFC Install and Repairs ND" || diary.Trim() == "HFC Install and Repairs SRVC")
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("M11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("M" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }

                            if (!_clientCodeFound)
                            {
                                _cellInfo = _myExcelWorksheet.get_Range("N11", _misValue).Formula.ToString();

                                if (_cellInfo == _job.ClientCodeDescription)
                                {
                                    _myExcelWorksheet.get_Range("N" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                    _clientCodeFound = true;
                                }
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("O11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("O" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("P11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("P" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("Q11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("Q" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("R11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("R" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("S11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("S" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("T11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("T" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("U11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("U" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("V11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("V" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("W11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("W" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("X11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("X" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("Y11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("Y" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("Z11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("Z" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AA11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AA" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AB11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AB" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AC11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AC" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AD11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AD" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AE11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AE" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AF11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AF" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AG11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AG" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AH11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AH" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AI11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AI" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AJ11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AJ" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AK11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AK" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AL11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AL" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }

                        if (!_clientCodeFound)
                        {
                            _cellInfo = _myExcelWorksheet.get_Range("AM11", _misValue).Formula.ToString();

                            if (_cellInfo == _job.ClientCodeDescription)
                            {
                                _myExcelWorksheet.get_Range("AM" + _startRow.ToString(), _misValue).Formula = _job.BillableQuantity;
                                _clientCodeFound = true;
                            }
                        }
                    }

                    _excelApp.ScreenUpdating = true;

                    string _path = saveDestination;                    
                    string _regionName = _jobInformation[0].Region.Trim();
                    string currentTime = DateTime.Now.ToString("_HH_mm_ss");

                    _myExcelWorksheet.SaveAs(_path + "\\" + _regionName + "-" + getDiaryInfo.SaveAs.Trim() + currentTime + ".xlsx", _misValue, _misValue, _misValue,
                                            _misValue, _misValue, _misValue, _misValue, _misValue, _misValue);

                    _excelWorkbooks.Close();
                    _excelApp.Quit();

                    Marshal.ReleaseComObject(_excelWorkbooks);
                    Marshal.ReleaseComObject(_excelWorkbooks);
                    Marshal.ReleaseComObject(_excelApp);                   

                    memoryManagement.FlushMemory();
                }
            }

            if (invoiceOption == 0 || invoiceOption == 1)
            {
                List<ImportedTransactionsView> _getImportedRecords = new List<ImportedTransactionsView>();

                if (rdBtnPayrollPeriod.IsChecked)
                {
                    int integerPayrollYear = Convert.ToInt32(payrollYear);
                    var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == payrollPeriod && x.PayrollYear == integerPayrollYear).FirstOrDefault();

                    DateTime openDate = getPeriodDates.OpenDate;
                    DateTime closeDate = getPeriodDates.CloseDate;

                    _getImportedRecords = dbContext.ImportedTransactionsViews.Where(x => x.TransactionDate >= openDate && x.TransactionDate <= closeDate
                                          && x.RegionId == selectedRegionId && x.BusinessLineId == selectedBusinessLineId && x.IsExported == false)
                                          .AsNoTracking().ToList();
                }
                else
                    _getImportedRecords = dbContext.ImportedTransactionsViews.Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate
                                          && x.RegionId == selectedRegionId && x.BusinessLineId == selectedBusinessLineId && x.IsExported == false)
                                          .AsNoTracking().ToList();

                foreach (var record in _getImportedRecords)
                {
                    var _getDataRow = dbContext.TransactionImports.Where(x => x.TransactionImportId == record.TransactionImportId).FirstOrDefault();

                    _getDataRow.IsExported = true;
                    _getDataRow.ExportedBy = ApplicationSecurityConstants._activeUser;
                    _getDataRow.DateExported = DateTime.Now;
                }
            }
        }

        private void BgwExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int index = System.Windows.Forms.Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (System.Windows.Forms.Application.OpenForms[index].Name == "FrmWaitDialogue")
                    System.Windows.Forms.Application.OpenForms[index].Close();
            }

            RadMessageBox.Show("Invoice exported successfully!", Application.ProductName);
        }

        private void FrmGenerateBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
            memoryManagement.FlushMemory();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void rdBtnPayrollPeriod_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdBtnPayrollPeriod.IsChecked)
            {
                dtpStartDate.Visible = false;
                dtpEndDate.Visible = false;

                ddlPeriod.Visible = true;
                ddlPeriod.Location = new Point(126, 145);
                ddlYear.Visible = true;
                ddlYear.Location = new Point(126, 172);

                lblPeriod.Text = "Payroll Period";
                lblYear.Text = "Payroll Year";
            }
        }

        private void rdBtnJobDate_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdBtnJobDate.IsChecked)
            {
                ddlPeriod.Visible = false;
                ddlYear.Visible = false;

                dtpStartDate.Visible = true;
                dtpStartDate.Location = new Point(126, 145);
                dtpEndDate.Visible = true;
                dtpEndDate.Location = new Point(126, 172);

                lblPeriod.Text = "Job Start Date";
                lblYear.Text = "Job End Date";
            }
        }
    }
}