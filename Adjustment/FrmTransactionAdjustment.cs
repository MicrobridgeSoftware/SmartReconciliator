using ApplicationSecurity;
using SmartReconciliator.ApplicationUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SmartReconciliator.Adjustment
{
    public partial class FrmTransactionAdjustment : Telerik.WinControls.UI.RadForm
    {
        ContractorManagementEntities dbContext = new ContractorManagementEntities();
        List<CM_AdjustmentType> adjustmentTypes;
        List<CM_PayrollConfig> payrollConfigs;
        List<payPeriodDefinition> _payrollConfig;

        public FrmTransactionAdjustment()
        {
            InitializeComponent();
        }

        private void FrmTransactionAdjustment_Load(object sender, EventArgs e)
        {
            adjustmentTypes = new List<CM_AdjustmentType>();
            payrollConfigs = new List<CM_PayrollConfig>();
            _payrollConfig = new List<payPeriodDefinition>();

            adjustmentTypes = dbContext.CM_AdjustmentType.Where(x=> x.AdjustmentTypeId == 2).AsNoTracking().ToList();
            payrollConfigs = dbContext.CM_PayrollConfig.Where(x => x.Active).AsNoTracking().ToList();

            payrollConfigs = dbContext.CM_PayrollConfig.Where(x => !x.Active).AsNoTracking().ToList();

            foreach (CM_PayrollConfig config in payrollConfigs)
                _payrollConfig.Add(new payPeriodDefinition { payPeriodName = config.PayrollPeriod.ToString() + " - " + config.OpenDate.ToShortDateString() + " to " + config.CloseDate.ToShortDateString(), payPeriodNo = config.PayrollPeriod, payPeriodYear = config.PayrollYear });

            List<payPeriodDefinition> distinctPeriods = new List<payPeriodDefinition>();
            List<payPeriodDefinition> distinctYears = new List<payPeriodDefinition>();

            foreach (payPeriodDefinition definition in _payrollConfig)
            {
                bool periodExists = distinctPeriods.Where(x => x.payPeriodNo == definition.payPeriodNo).Any();

                if (!periodExists)
                    distinctPeriods.Add(definition);

                bool yearExists = distinctYears.Where(x => x.payPeriodYear == definition.payPeriodYear).Any();

                if (!yearExists)
                    distinctYears.Add(definition);
            }

            bindingSourcePeriod.DataSource = distinctPeriods.OrderBy(x => x.payPeriodNo);
            bindingSourceYear.DataSource = distinctYears.OrderByDescending(x => x.payPeriodYear);
            bindingSourceAdjType.DataSource = adjustmentTypes;
        }

        private void BtnRecover_Click(object sender, EventArgs e)
        {
            if (ddlAdjustmentType.SelectedValue == null || Convert.ToInt32(ddlAdjustmentType.SelectedValue) == 0)
            {
                RadMessageBox.Show("An Adjustment type is required to continue!", Application.ProductName);
                return;
            }

            if (ddlPeriod.SelectedValue == null || Convert.ToInt32(ddlPeriod.SelectedValue) == 0)
            {
                RadMessageBox.Show("A payroll period is required to continue!", Application.ProductName);
                return;
            }

            if (ddlYear.SelectedValue == null || Convert.ToInt32(ddlYear.SelectedValue) == 0)
            {
                RadMessageBox.Show("A payroll year is required to continue!", Application.ProductName);
                return;
            }

            DialogResult promptUser = RadMessageBox.Show("Are you sure you want to proceed with this transaction?", Application.ProductName, MessageBoxButtons.YesNo);

            if (promptUser == DialogResult.Yes)
            {
                try
                {
                    int adjustmentTypeId = Convert.ToInt32(ddlAdjustmentType.SelectedValue);
                    int previousPayPeriod = Convert.ToInt32(ddlPeriod.SelectedValue);
                    int previousPayYear = Convert.ToInt32(ddlYear.SelectedValue);

                    var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == previousPayPeriod && x.PayrollYear == previousPayYear).FirstOrDefault();

                    DateTime openDate = getPeriodDates.OpenDate;
                    DateTime closeDate = getPeriodDates.CloseDate;

                    bool isRequestValid = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionDate >= openDate && x.TransactionDate <= closeDate
                                          && x.TransactionImport.DifferenceRecovered == false).Any();

                    if (!isRequestValid)
                    {
                        RadMessageBox.Show("This period has already been recovered or was not imported!", Application.ProductName);
                        return;
                    }

                    bool techicianPaidForThisPeriod = dbContext.JobLogDetailsViews.Where(x => x.PayrollPeriod == previousPayPeriod && x.PayrollYear == previousPayYear.ToString()
                                                     && x.IsExported != null).Any();

                    if (!techicianPaidForThisPeriod)
                    {
                        RadMessageBox.Show("Technicians are not yet paid for this period!", Application.ProductName);
                        return;
                    }

                    if (bgwRecovery.IsBusy)
                    {
                        RadMessageBox.Show("System currently executing other processes.\n" +
                                           "This process cannot be executed at this time!", System.Windows.Forms.Application.ProductName);
                        return;
                    }

                    List<JobLogDetailsView> getJobDetails = new List<JobLogDetailsView>();

                    var getImportedTransactions = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionDate >= openDate && x.TransactionDate <= closeDate
                                                  && x.TransactionImport.DifferenceRecovered == false).ToList();

                    foreach (var transaction in getImportedTransactions)
                    {
                        string ticketNo = transaction.JobNumber.Trim().ToUpper();

                        var jobDetail = dbContext.JobLogDetailsViews.Where(x => x.PayrollPeriod == previousPayPeriod && x.PayrollYear == previousPayYear.ToString()
                                        && x.TicketNo == ticketNo && x.LeadContractor == 1).AsNoTracking().ToList();

                        if (jobDetail.Count > 0)
                        {
                            foreach (var detail in jobDetail)
                                getJobDetails.Add(detail);
                        }
                    }

                    if (getJobDetails.Count <= 0)
                    {
                        RadMessageBox.Show("No matching data found!", Application.ProductName);
                        return;
                    }

                    List<int> jobLogIds = new List<int>();
                    FrmTransactionSelection transactionSelection = new FrmTransactionSelection(getJobDetails, jobLogIds);
                    transactionSelection.ShowDialog();

                    if (jobLogIds.Count <= 0)
                    {
                        RadMessageBox.Show("Atleast one transaction must be selected to be reversed!", Application.ProductName);
                        return;
                    }

                    FrmWaitDialogue _waitDialogue = new FrmWaitDialogue();

                    List<object> bgwarguments = new List<object>();
                    bgwarguments.Add(adjustmentTypeId);
                    bgwarguments.Add(previousPayPeriod);
                    bgwarguments.Add(previousPayYear);
                    bgwarguments.Add(jobLogIds);

                    bgwRecovery.RunWorkerAsync(bgwarguments);
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

        private void FrmTransactionAdjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }

        private void bgwRecovery_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> _argumentList = e.Argument as List<object>;
            List<int> selectedJobIds = new List<int>();
            int adjustmentId = Convert.ToInt32(_argumentList[0]);
            int prevPayPeriod = Convert.ToInt32(_argumentList[1]);
            int prevPayYear = Convert.ToInt32(_argumentList[2]);

            foreach (int id in _argumentList[3] as List<int>)
                selectedJobIds.Add(id);

            var getActivePayrollPeriod = dbContext.CM_PayrollConfig.Where(x => x.Active == true).FirstOrDefault();
            //List<string> jobNo = new List<string>();
            //List<DateTime> transDate = new List<DateTime>();
            List<JobLogDetailsView> getJobDetails = new List<JobLogDetailsView>();

            //var getImportedTransactions = dbContext.ImportedTransactionsViews.Where(x => x.PayrollPeriod == prevPayPeriod && x.PayrollYear == prevPayYear).AsNoTracking().ToList();

            foreach(int logId in selectedJobIds)// foreach (var transaction in getImportedTransactions)
            {
                var jobDetail = dbContext.JobLogDetailsViews.Where(x => x.JobLogId == logId && x.IsExported == true).AsNoTracking().ToList();

                if (jobDetail.Count > 0)
                {
                    foreach(var detail in jobDetail)
                        getJobDetails.Add(detail);
                }
            }
            
            foreach (var jobDetails in getJobDetails)
            {
                CM_Adjustment adjustment = new CM_Adjustment();
                adjustment.JobLogId = jobDetails.JobLogId;
                adjustment.PayrollPeriod = (byte)getActivePayrollPeriod.PayrollPeriod;
                adjustment.PayrollYear = getActivePayrollPeriod.PayrollYear.ToString();
                adjustment.AdjustmentTypeId = (short)adjustmentId;
                adjustment.AdjustmentAmount = Convert.ToDecimal(jobDetails.Rate) * -1;
                adjustment.AdjustmentNote = "FLOW reconciliation payment reversal";
                adjustment.AdjustmentDate = DateTime.Today.Date;

                dbContext.CM_Adjustment.Add(adjustment);
            }

            dbContext.SaveChanges();

            var getPeriodDates = payrollConfigs.Where(x => x.PayrollPeriod == prevPayPeriod && x.PayrollYear == prevPayYear).FirstOrDefault();

            DateTime openDate = getPeriodDates.OpenDate;
            DateTime closeDate = getPeriodDates.CloseDate;

            var updateImportRecord = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionDate >= openDate && x.TransactionDate <= closeDate
                                  && x.TransactionImport.DifferenceRecovered == false).FirstOrDefault();


            //var updateImportRecord = dbContext.TransactionImports.Where(x => x.PayrollPeriod == prevPayPeriod && x.PayrollYear == prevPayYear).FirstOrDefault();

            if (updateImportRecord != null)
            {
                updateImportRecord.TransactionImport.DifferenceRecovered = true;
                updateImportRecord.TransactionImport.RecoveredBy = ApplicationSecurityConstants._activeUser;
                updateImportRecord.TransactionImport.RecoveryDate = DateTime.Now;

                dbContext.SaveChanges();
            }

            e.Result = getJobDetails.Count;
        }

        private void bgwRecovery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int index = System.Windows.Forms.Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (System.Windows.Forms.Application.OpenForms[index].Name == "FrmWaitDialogue")
                    System.Windows.Forms.Application.OpenForms[index].Close();
            }

            string recordCount = e.Result as string;

            RadMessageBox.Show(recordCount + " transaction(s) updated successfully!", System.Windows.Forms.Application.ProductName);
        }
    }
}