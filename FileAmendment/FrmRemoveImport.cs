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

namespace SmartReconciliator.FileAmendment
{
    public partial class FrmRemoveImport : Telerik.WinControls.UI.RadForm
    {
        ContractorManagementEntities dbContext = new ContractorManagementEntities();
        List<TransactionImport> transactions;

        public FrmRemoveImport()
        {
            InitializeComponent();
        }

        private void FrmRemoveImport_Load(object sender, EventArgs e)
        {
            transactions = new List<TransactionImport>();
            transactions = dbContext.TransactionImports.Where(x => !x.IsExported).AsNoTracking().ToList();

            grdDataDisplay.DataSource = transactions;
        }

        private void bgwRemoveRecord_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> _argumentList = e.Argument as List<object>;
            int id = Convert.ToInt32(_argumentList[0]);

            var _getDetailsForDelete = dbContext.TransactionImportAccountNoes.Where(x => x.TransactionImportId == id).ToList();

            foreach (var detail in _getDetailsForDelete)
                dbContext.TransactionImportAccountNoes.Remove(detail);

            dbContext.SaveChanges();

            var _removeHeaderFile = dbContext.TransactionImports.Where(x => x.TransactionImportId == id).FirstOrDefault();

            if (_removeHeaderFile != null)
                dbContext.TransactionImports.Remove(_removeHeaderFile);

            dbContext.SaveChanges();

            e.Result = id;
        }

        private void bgwRemoveRecord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int index = System.Windows.Forms.Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (System.Windows.Forms.Application.OpenForms[index].Name == "FrmWaitDialogue")
                    System.Windows.Forms.Application.OpenForms[index].Close();
            }

            string importId = e.Result as string;

            if (importId != string.Empty)
            {
                int impId = Convert.ToInt32(importId);

                if (impId > 0)
                {
                    var _findGridviewRecords = grdDataDisplay.Rows.Where(x => Convert.ToInt32(x.Cells["TransactionImportId"].Value) == impId).ToList();

                    foreach (var _record in _findGridviewRecords)
                        this.grdDataDisplay.Rows.Remove(_record);
                }
            }
            
            transactions = new List<TransactionImport>();
            transactions = dbContext.TransactionImports.Where(x => !x.IsExported).AsNoTracking().ToList();
            grdDataDisplay.DataSource = transactions;

            RadMessageBox.Show("File deleted successfully!", System.Windows.Forms.Application.ProductName);
        }

        private void grdDataDisplay_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            DialogResult promptUser = RadMessageBox.Show("Are you sure you want to remove this import?", Application.ProductName, MessageBoxButtons.YesNo);

            if (promptUser == DialogResult.Yes)
            {
                if (e.Row.Cells["TransactionImportId"].Value == null)
                    return;

                int importId = Convert.ToInt32(e.Row.Cells["TransactionImportId"].Value);

                if (importId > 0)
                {
                    FrmWaitDialogue _waitDialogue = new FrmWaitDialogue();
                    List<object> bgwarguments = new List<object>();
                    bgwarguments.Add(importId);

                    try
                    {
                        if (bgwRemoveRecord.IsBusy)
                        {
                            RadMessageBox.Show("System currently executing other processes.\n" +
                                               "This process cannot be executed at this time!", System.Windows.Forms.Application.ProductName);
                            return;
                        }

                        bgwRemoveRecord.RunWorkerAsync(bgwarguments);
                        _waitDialogue.ShowDialog();
                    }
                    catch (Exception exp)
                    {
                        RadMessageBox.Show(exp.InnerException == null ? exp.Message : exp.InnerException.Message);
                    }
                }
            }
        }

        private void FrmRemoveImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }
    }
}