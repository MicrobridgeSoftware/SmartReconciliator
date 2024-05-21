namespace SmartReconciliator.Export
{
    partial class FrmGenerateBill
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceRegion = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddlBusinessLine = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceBusinessLine = new System.Windows.Forms.BindingSource(this.components);
            this.lblYear = new Telerik.WinControls.UI.RadLabel();
            this.lblPeriod = new Telerik.WinControls.UI.RadLabel();
            this.ddlYear = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceYear = new System.Windows.Forms.BindingSource(this.components);
            this.ddlPeriod = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourcePeriod = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlInvoiceOptions = new Telerik.WinControls.UI.RadDropDownList();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.BtnImport = new Telerik.WinControls.UI.RadButton();
            this.BgwExport = new System.ComponentModel.BackgroundWorker();
            this.dtpStartDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpEndDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdBtnPayrollPeriod = new Telerik.WinControls.UI.RadRadioButton();
            this.rdBtnJobDate = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBusinessLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBusinessLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdBtnPayrollPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdBtnJobDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.dtpEndDate);
            this.radGroupBox1.Controls.Add(this.dtpStartDate);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.ddlRegion);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.ddlBusinessLine);
            this.radGroupBox1.Controls.Add(this.lblYear);
            this.radGroupBox1.Controls.Add(this.lblPeriod);
            this.radGroupBox1.Controls.Add(this.ddlYear);
            this.radGroupBox1.Controls.Add(this.ddlPeriod);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.ddlInvoiceOptions);
            this.radGroupBox1.HeaderText = "Invoice Processing";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(487, 198);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Invoice Processing";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(69, 118);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(47, 18);
            this.radLabel7.TabIndex = 29;
            this.radLabel7.Text = "Region\r\n";
            // 
            // ddlRegion
            // 
            this.ddlRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRegion.DataSource = this.bindingSourceRegion;
            this.ddlRegion.DisplayMember = "RegionDescription";
            this.ddlRegion.Location = new System.Drawing.Point(126, 118);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.Size = new System.Drawing.Size(273, 20);
            this.ddlRegion.TabIndex = 28;
            this.ddlRegion.ValueMember = "RegionId";
            // 
            // bindingSourceRegion
            // 
            this.bindingSourceRegion.DataSource = typeof(SmartReconciliator.RegionView);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(44, 91);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(72, 18);
            this.radLabel4.TabIndex = 27;
            this.radLabel4.Text = "Business Line";
            // 
            // ddlBusinessLine
            // 
            this.ddlBusinessLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBusinessLine.DataSource = this.bindingSourceBusinessLine;
            this.ddlBusinessLine.DisplayMember = "BusinessLineDescription";
            this.ddlBusinessLine.Location = new System.Drawing.Point(126, 91);
            this.ddlBusinessLine.Name = "ddlBusinessLine";
            this.ddlBusinessLine.Size = new System.Drawing.Size(273, 20);
            this.ddlBusinessLine.TabIndex = 26;
            this.ddlBusinessLine.ValueMember = "BusinessLineId";
            // 
            // bindingSourceBusinessLine
            // 
            this.bindingSourceBusinessLine.DataSource = typeof(SmartReconciliator.CM_BusinessLine);
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(51, 172);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(65, 18);
            this.lblYear.TabIndex = 8;
            this.lblYear.Text = "Payroll Year";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(41, 145);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(75, 18);
            this.lblPeriod.TabIndex = 7;
            this.lblPeriod.Text = "Payroll Period";
            // 
            // ddlYear
            // 
            this.ddlYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlYear.DataSource = this.bindingSourceYear;
            this.ddlYear.DisplayMember = "payPeriodYear";
            this.ddlYear.Location = new System.Drawing.Point(126, 172);
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
            this.ddlPeriod.Location = new System.Drawing.Point(126, 145);
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
            this.radLabel1.Location = new System.Drawing.Point(32, 64);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Invoice Options";
            // 
            // ddlInvoiceOptions
            // 
            this.ddlInvoiceOptions.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem4.Text = "Convert Imported file to Invoice";
            radListDataItem5.Text = "Merge Import file with Data Entry";
            radListDataItem6.Text = "Convert Data Entry to Invoice (exclude import)";
            this.ddlInvoiceOptions.Items.Add(radListDataItem4);
            this.ddlInvoiceOptions.Items.Add(radListDataItem5);
            this.ddlInvoiceOptions.Items.Add(radListDataItem6);
            this.ddlInvoiceOptions.Location = new System.Drawing.Point(126, 64);
            this.ddlInvoiceOptions.Name = "ddlInvoiceOptions";
            this.ddlInvoiceOptions.Size = new System.Drawing.Size(273, 20);
            this.ddlInvoiceOptions.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(127, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(33, 219);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(91, 28);
            this.BtnImport.TabIndex = 3;
            this.BtnImport.Text = "Create Invoice";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BgwExport
            // 
            this.BgwExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwExport_DoWork);
            this.BgwExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwExport_RunWorkerCompleted);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(270, 144);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(164, 20);
            this.dtpStartDate.TabIndex = 30;
            this.dtpStartDate.TabStop = false;
            this.dtpStartDate.Text = "Tuesday, October 20, 2020";
            this.dtpStartDate.Value = new System.DateTime(2020, 10, 20, 12, 26, 20, 850);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(270, 171);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(164, 20);
            this.dtpEndDate.TabIndex = 31;
            this.dtpEndDate.TabStop = false;
            this.dtpEndDate.Text = "Tuesday, October 20, 2020";
            this.dtpEndDate.Value = new System.DateTime(2020, 10, 20, 12, 26, 32, 704);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rdBtnJobDate);
            this.radGroupBox2.Controls.Add(this.rdBtnPayrollPeriod);
            this.radGroupBox2.HeaderText = "Export Option";
            this.radGroupBox2.Location = new System.Drawing.Point(53, 14);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(383, 42);
            this.radGroupBox2.TabIndex = 5;
            this.radGroupBox2.Text = "Export Option";
            // 
            // rdBtnPayrollPeriod
            // 
            this.rdBtnPayrollPeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdBtnPayrollPeriod.Location = new System.Drawing.Point(91, 16);
            this.rdBtnPayrollPeriod.Name = "rdBtnPayrollPeriod";
            this.rdBtnPayrollPeriod.Size = new System.Drawing.Size(104, 18);
            this.rdBtnPayrollPeriod.TabIndex = 0;
            this.rdBtnPayrollPeriod.Text = "By Payroll Period";
            this.rdBtnPayrollPeriod.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rdBtnPayrollPeriod.CheckStateChanged += new System.EventHandler(this.rdBtnPayrollPeriod_CheckStateChanged);
            // 
            // rdBtnJobDate
            // 
            this.rdBtnJobDate.Location = new System.Drawing.Point(225, 16);
            this.rdBtnJobDate.Name = "rdBtnJobDate";
            this.rdBtnJobDate.Size = new System.Drawing.Size(79, 18);
            this.rdBtnJobDate.TabIndex = 1;
            this.rdBtnJobDate.TabStop = false;
            this.rdBtnJobDate.Text = "By Job Date";
            this.rdBtnJobDate.CheckStateChanged += new System.EventHandler(this.rdBtnJobDate_CheckStateChanged);
            // 
            // FrmGenerateBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 258);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenerateBill";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Generate Invoice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGenerateBill_FormClosing);
            this.Load += new System.EventHandler(this.FrmGenerateBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBusinessLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBusinessLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdBtnPayrollPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdBtnJobDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblYear;
        private Telerik.WinControls.UI.RadLabel lblPeriod;
        private Telerik.WinControls.UI.RadDropDownList ddlYear;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriod;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlInvoiceOptions;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton BtnImport;
        private System.Windows.Forms.BindingSource bindingSourcePeriod;
        private System.Windows.Forms.BindingSource bindingSourceYear;
        private System.ComponentModel.BackgroundWorker BgwExport;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddlBusinessLine;
        private System.Windows.Forms.BindingSource bindingSourceBusinessLine;
        private System.Windows.Forms.BindingSource bindingSourceRegion;
        private Telerik.WinControls.UI.RadDateTimePicker dtpEndDate;
        private Telerik.WinControls.UI.RadDateTimePicker dtpStartDate;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rdBtnJobDate;
        private Telerik.WinControls.UI.RadRadioButton rdBtnPayrollPeriod;
    }
}
