using ApplicationSecurity;
using Microsoft.Office.Interop.Excel;
using SmartReconciliator.ApplicationUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SmartReconciliator
{
    public partial class FrmFileImport : Telerik.WinControls.UI.RadForm
    {
        ContractorManagementEntities dbContext = new ContractorManagementEntities();
        List<workSheetDefinition> workSheets;
        List<payPeriodDefinition> payPeriods;
        List<CM_PayrollConfig> payrollConfigs;
        List<CM_BusinessLine> businessLines;
        List<RegionView> regionViews;

        public FrmFileImport()
        {
            InitializeComponent();
        }

        private void BgwFileImport_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> _argumentList = e.Argument as List<object>;
            string mode = _argumentList[0].ToString();

            if (mode.Equals("FetchWorkSheets"))
            {
                string fileQuery = _argumentList[1].ToString().Trim();
                workSheets = new List<workSheetDefinition>();

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(fileQuery);

                int sheet = 0;

                foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
                {
                    workSheets.Add(new workSheetDefinition { sheetName = wSheet.Name, sheetNo = sheet });                    
                    sheet++;
                }

                excelBook.Close();
                xlApp.Workbooks.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(excelBook);
                Marshal.ReleaseComObject(xlApp);
                memoryManagement.FlushMemory();
            }

            if (mode.Equals("DataImport"))
            {
                string fileQuery = _argumentList[1].ToString().Trim();
                string sheetName = _argumentList[2].ToString().Trim();
                string columnName = _argumentList[3].ToString().Trim();
                int startRow = Convert.ToInt32(_argumentList[4]);
                string transdateColumnName = _argumentList[7].ToString().Trim();
                List<fileImportDefinition> accountNumberImport = new List<fileImportDefinition>();
                
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(fileQuery);
                                
                foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
                {
                    if (wSheet.Name.Trim().Equals(sheetName))
                    {
                        wSheet.Activate();
                        int rowCount = wSheet.UsedRange.Rows.Count;

                        for (int row = startRow; row < rowCount; row++)
                        {
                            var cellValue = wSheet.Cells[row, columnName];
                            var dateCellValue = wSheet.Cells[row, transdateColumnName];

                            if (cellValue != null && cellValue.Text.ToString().Trim() != string.Empty && dateCellValue != null && dateCellValue.Text.ToString().Trim() != string.Empty)
                                accountNumberImport.Add(new fileImportDefinition { accountNumber = cellValue.Text.ToString().Trim(), transactionDate = dateCellValue.Text.ToString().Trim() });
                        }
                    }
                }

                string fileName = Path.GetFileName(fileQuery);
                int importedRecordCount = accountNumberImport.Count;
                int businessLine = Convert.ToInt32(_argumentList[5]);
                int region = Convert.ToInt32(_argumentList[6]);

                TransactionImport import = new TransactionImport();
                import.CreatedBy = ApplicationSecurityConstants._activeUser;
                import.DateCreated = DateTime.Now;
                import.FileName = fileName;
                import.IsExported = false;
                import.PayrollPeriod = 0;
                import.PayrollYear = 0;
                import.RecordCount = importedRecordCount;
                import.ReferencedColumn = columnName;
                import.ReferencedDateColumn = transdateColumnName;
                import.SelectedStartRow = startRow;
                import.SheetName = sheetName;
                import.DifferenceRecovered = false;
                import.BusinessLineId = businessLine;
                import.RegionId = region;
                dbContext.TransactionImports.Add(import);
                dbContext.SaveChanges();

                int newImportId = import.TransactionImportId;
                
                foreach (fileImportDefinition file in accountNumberImport)
                {
                    TransactionImportAccountNo accountNo = new TransactionImportAccountNo();
                    accountNo.TransactionImportId = newImportId;
                    accountNo.JobNumber = file.accountNumber;
                    accountNo.TransactionDate = Convert.ToDateTime(file.transactionDate).Date;
                    dbContext.TransactionImportAccountNoes.Add(accountNo);
                }

                dbContext.SaveChanges();

                excelBook.Close();
                xlApp.Workbooks.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(excelBook);
                Marshal.ReleaseComObject(xlApp);
                memoryManagement.FlushMemory();
            }

            e.Result = mode;
        }

        private void rbeFile_ValueChanged(object sender, EventArgs e)
        {
            if (rbeFile.Value != string.Empty)
            {
                List<object> bgwarguments = new List<object>();
                bgwarguments.Add("FetchWorkSheets");
                bgwarguments.Add(rbeFile.Value.ToString());

                if (BgwFileImport.IsBusy)
                {
                    RadMessageBox.Show("System currently executing other processes.\n" +
                                       "This process cannot be executed at this time!", System.Windows.Forms.Application.ProductName);
                    return;
                }

                try
                {
                    BgwFileImport.RunWorkerAsync(bgwarguments);
                }
                catch (Exception exp)
                {
                    RadMessageBox.Show(exp.InnerException == null ? exp.Message : exp.InnerException.Message);
                }
            }
        }

        private void BgwFileImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int index = System.Windows.Forms.Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (System.Windows.Forms.Application.OpenForms[index].Name == "FrmWaitDialogue")
                    System.Windows.Forms.Application.OpenForms[index].Close();
            }

            string processName = e.Result as string;

            if (processName.Equals("FetchWorkSheets"))
                bindingSourceSheet.DataSource = workSheets;
            else if (processName.Equals("DataImport"))
            {
                ddlBusinessLine.SelectedIndex = -1;
                ddlRegion.SelectedIndex = -1;
                ddlWorkSheet.SelectedIndex = -1;
                txtAccountNo.Text = string.Empty;
                txtTransDate.Text = string.Empty;
                spinStartRow.Value = 1;

                RadMessageBox.Show("File imported successfully!", System.Windows.Forms.Application.ProductName);
            }
        }

        private void FrmFileImport_Load(object sender, EventArgs e)
        {
            payrollConfigs = new List<CM_PayrollConfig>();
            payPeriods = new List<payPeriodDefinition>();
            businessLines = new List<CM_BusinessLine>();
            regionViews = new List<RegionView>();

            //int previousYear = DateTime.Now.Year - 1;
            //payrollConfigs = dbContext.CM_PayrollConfig.Where(x => !x.Active /*&& x.CloseDate.Year >= previousYear*/).AsNoTracking().ToList();

            //foreach (CM_PayrollConfig config in payrollConfigs)
            //    payPeriods.Add(new payPeriodDefinition { payPeriodName = config.PayrollPeriod.ToString() + " - " + config.OpenDate.ToShortDateString() + " to " + config.CloseDate.ToShortDateString(), payPeriodNo = config.PayrollPeriod, payPeriodYear = config.PayrollYear });

            //bindingSourcePeriod.DataSource = payPeriods;

            businessLines = dbContext.CM_BusinessLine.Where(x => x.Active).AsNoTracking().ToList();
            regionViews = dbContext.RegionViews.AsNoTracking().ToList();

            bindingSourceBusinessLine.DataSource = businessLines;
            bindingSourceRegion.DataSource = regionViews;

            ddlBusinessLine.SelectedIndex = -1;
            ddlRegion.SelectedIndex = -1;

            this.ddlBusinessLine.DropDownListElement.AutoCompleteAppend.LimitToList = true;
            this.ddlWorkSheet.DropDownListElement.AutoCompleteAppend.LimitToList = true;
            this.ddlRegion.DropDownListElement.AutoCompleteAppend.LimitToList = true;
        }

        private void FrmFileImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (rbeFile.Value == string.Empty || rbeFile.Value == null)
            {
                RadMessageBox.Show("Select the file you would like to import", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (ddlBusinessLine.SelectedValue == null || ddlBusinessLine.SelectedIndex == -1)
            {
                RadMessageBox.Show("Select the appropriate business line to continue", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (ddlWorkSheet.SelectedValue == null || ddlWorkSheet.SelectedIndex == -1)
            {
                RadMessageBox.Show("Select the worksheet that should be imported from the file", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (txtAccountNo.Text.Trim() == string.Empty)
            {
                RadMessageBox.Show("Enter the column that contains the account number in the respective file", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (txtTransDate.Text.Trim() == string.Empty)
            {
                RadMessageBox.Show("Enter the column that contains the transaction date in the respective file", System.Windows.Forms.Application.ProductName);
                return;
            }

            if (ddlRegion.SelectedValue == null || ddlRegion.SelectedIndex == -1)
            {
                RadMessageBox.Show("Select the appropriate region to continue", System.Windows.Forms.Application.ProductName);
                return;
            }

            DialogResult ConfirmExport = RadMessageBox.Show("Are you sure you want to proceed with this import?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNo);
            
            if (ConfirmExport == DialogResult.Yes)
            {
                try
                {
                    FrmWaitDialogue _waitDialogue = new FrmWaitDialogue();
                    int businessLineId = Convert.ToInt32(ddlBusinessLine.SelectedValue);
                    int regionId = Convert.ToInt32(ddlRegion.SelectedValue);

                    List<object> bgwarguments = new List<object>();
                    bgwarguments.Add("DataImport");
                    bgwarguments.Add(rbeFile.Value.ToString());
                    bgwarguments.Add(ddlWorkSheet.SelectedValue.ToString().Trim());
                    bgwarguments.Add(txtAccountNo.Text.Trim());
                    bgwarguments.Add(spinStartRow.Value);
                    bgwarguments.Add(businessLineId);
                    bgwarguments.Add(regionId);
                    bgwarguments.Add(txtTransDate.Text.Trim());

                    if (BgwFileImport.IsBusy)
                    {
                        RadMessageBox.Show("System currently executing other processes.\n" +
                                           "This process cannot be executed at this time!", System.Windows.Forms.Application.ProductName);
                        return;
                    }

                    BgwFileImport.RunWorkerAsync(bgwarguments);
                    _waitDialogue.ShowDialog();
                }
                catch (Exception exp)
                {
                    RadMessageBox.Show(exp.InnerException == null ? exp.Message : exp.InnerException.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}