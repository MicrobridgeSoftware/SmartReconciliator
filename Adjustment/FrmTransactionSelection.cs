using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SmartReconciliator.Adjustment
{
    public partial class FrmTransactionSelection : Telerik.WinControls.UI.RadForm
    {
        private List<JobLogDetailsView> getJobDetails;
        private List<int> jobLogIds;

        public FrmTransactionSelection()
        {
            InitializeComponent();
        }

        public FrmTransactionSelection(List<JobLogDetailsView> getJobDetails, List<int> jobLogIds) : this()
        {
            this.getJobDetails = getJobDetails;
            this.jobLogIds = jobLogIds;
        }

        private void FrmTransactionSelection_Load(object sender, EventArgs e)
        {
            grdDataDisplay.DataSource = getJobDetails;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grdDataDisplay.Rows.Count <= 0)
                return;

            var getSelectedRows = grdDataDisplay.Rows.Where(x => x.Cells["Select"].Value != null && Convert.ToBoolean(x.Cells["Select"].Value) == true).ToList();

            if (getSelectedRows.Count <= 0)
            {
                RadMessageBox.Show("No rows were selected for payment recovery!", Application.ProductName);
                return;
            }

            DialogResult promptUser = RadMessageBox.Show("Are you sure you want to reverse the payment of these transactions?", Application.ProductName, MessageBoxButtons.YesNo);

            if (promptUser == DialogResult.Yes)
            {
                foreach (var row in getSelectedRows)
                    jobLogIds.Add(Convert.ToInt32(row.Cells["JobLogId"].Value));

                Close();
            }
        }
    }
}