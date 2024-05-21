namespace SmartReconciliator.Adjustment
{
    partial class FrmTransactionAdjustment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.BtnRecover = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlYear = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceYear = new System.Windows.Forms.BindingSource(this.components);
            this.ddlPeriod = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourcePeriod = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlAdjustmentType = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceAdjType = new System.Windows.Forms.BindingSource(this.components);
            this.bgwRecovery = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnRecover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAdjustmentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdjType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(128, 178);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BtnRecover
            // 
            this.BtnRecover.Location = new System.Drawing.Point(28, 178);
            this.BtnRecover.Name = "BtnRecover";
            this.BtnRecover.Size = new System.Drawing.Size(97, 28);
            this.BtnRecover.TabIndex = 6;
            this.BtnRecover.Text = "Recover Funds";
            this.BtnRecover.Click += new System.EventHandler(this.BtnRecover_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.ddlYear);
            this.radGroupBox1.Controls.Add(this.ddlPeriod);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.ddlAdjustmentType);
            this.radGroupBox1.HeaderText = "Invoice Processing";
            this.radGroupBox1.Location = new System.Drawing.Point(14, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(460, 150);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Invoice Processing";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(51, 97);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(65, 18);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Payroll Year";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(41, 68);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(75, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Payroll Period";
            // 
            // ddlYear
            // 
            this.ddlYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlYear.DataSource = this.bindingSourceYear;
            this.ddlYear.DisplayMember = "payPeriodYear";
            this.ddlYear.Location = new System.Drawing.Point(126, 97);
            this.ddlYear.Name = "ddlYear";
            this.ddlYear.Size = new System.Drawing.Size(125, 20);
            this.ddlYear.TabIndex = 6;
            this.ddlYear.ValueMember = "payPeriodYear";
            // 
            // bindingSourceYear
            // 
            this.bindingSourceYear.DataSource = typeof(SmartReconciliator.ApplicationUtil.payPeriodDefinition);
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlPeriod.DataSource = this.bindingSourcePeriod;
            this.ddlPeriod.DisplayMember = "payPeriodNo";
            this.ddlPeriod.Location = new System.Drawing.Point(126, 68);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Size = new System.Drawing.Size(125, 20);
            this.ddlPeriod.TabIndex = 5;
            this.ddlPeriod.ValueMember = "payPeriodNo";
            // 
            // bindingSourcePeriod
            // 
            this.bindingSourcePeriod.DataSource = typeof(SmartReconciliator.ApplicationUtil.payPeriodDefinition);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(25, 39);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(91, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Adjustment Type";
            // 
            // ddlAdjustmentType
            // 
            this.ddlAdjustmentType.DataSource = this.bindingSourceAdjType;
            this.ddlAdjustmentType.DisplayMember = "AdjustmentType";
            this.ddlAdjustmentType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlAdjustmentType.Location = new System.Drawing.Point(126, 39);
            this.ddlAdjustmentType.Name = "ddlAdjustmentType";
            this.ddlAdjustmentType.Size = new System.Drawing.Size(273, 20);
            this.ddlAdjustmentType.TabIndex = 3;
            this.ddlAdjustmentType.ValueMember = "AdjustmentTypeId";
            // 
            // bindingSourceAdjType
            // 
            this.bindingSourceAdjType.DataSource = typeof(SmartReconciliator.CM_AdjustmentType);
            // 
            // bgwRecovery
            // 
            this.bgwRecovery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRecovery_DoWork);
            this.bgwRecovery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRecovery_RunWorkerCompleted);
            // 
            // FrmTransactionAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 218);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnRecover);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransactionAdjustment";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Transaction Adjustment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTransactionAdjustment_FormClosing);
            this.Load += new System.EventHandler(this.FrmTransactionAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnRecover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAdjustmentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAdjType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton BtnRecover;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlYear;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriod;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlAdjustmentType;
        private System.Windows.Forms.BindingSource bindingSourceAdjType;
        private System.ComponentModel.BackgroundWorker bgwRecovery;
        private System.Windows.Forms.BindingSource bindingSourcePeriod;
        private System.Windows.Forms.BindingSource bindingSourceYear;
    }
}
