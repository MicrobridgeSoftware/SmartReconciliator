namespace SmartReconciliator
{
    partial class FrmFileImport
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtTransDate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.ddlWorkSheet = new Telerik.WinControls.UI.RadDropDownList();
            this.spinStartRow = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtAccountNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlBusinessLine = new Telerik.WinControls.UI.RadDropDownList();
            this.rbeFile = new Telerik.WinControls.UI.RadBrowseEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.BtnImport = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.BgwFileImport = new System.ComponentModel.BackgroundWorker();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceBusinessLine = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRegion = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourcePeriod = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSheet = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWorkSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinStartRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBusinessLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbeFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBusinessLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.ddlRegion);
            this.radGroupBox1.Controls.Add(this.txtTransDate);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.ddlWorkSheet);
            this.radGroupBox1.Controls.Add(this.spinStartRow);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.txtAccountNo);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.ddlBusinessLine);
            this.radGroupBox1.Controls.Add(this.rbeFile);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "File Processing";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(506, 221);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "File Processing";
            // 
            // txtTransDate
            // 
            this.txtTransDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransDate.Location = new System.Drawing.Point(142, 158);
            this.txtTransDate.Name = "txtTransDate";
            this.txtTransDate.Size = new System.Drawing.Size(66, 20);
            this.txtTransDate.TabIndex = 23;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(31, 159);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(104, 18);
            this.radLabel4.TabIndex = 22;
            this.radLabel4.Text = "Trans. Date Column";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(71, 48);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(64, 18);
            this.radLabel6.TabIndex = 21;
            this.radLabel6.Text = "Work Sheet";
            // 
            // ddlWorkSheet
            // 
            this.ddlWorkSheet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlWorkSheet.DataSource = this.bindingSourceSheet;
            this.ddlWorkSheet.DisplayMember = "sheetName";
            this.ddlWorkSheet.Location = new System.Drawing.Point(142, 48);
            this.ddlWorkSheet.Name = "ddlWorkSheet";
            this.ddlWorkSheet.Size = new System.Drawing.Size(293, 20);
            this.ddlWorkSheet.TabIndex = 20;
            this.ddlWorkSheet.ValueMember = "sheetName";
            // 
            // spinStartRow
            // 
            this.spinStartRow.Location = new System.Drawing.Point(142, 185);
            this.spinStartRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinStartRow.Name = "spinStartRow";
            this.spinStartRow.NullableValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinStartRow.ShowUpDownButtons = false;
            this.spinStartRow.Size = new System.Drawing.Size(66, 20);
            this.spinStartRow.TabIndex = 19;
            this.spinStartRow.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinStartRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(81, 186);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(54, 18);
            this.radLabel5.TabIndex = 18;
            this.radLabel5.Text = "Start Row";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountNo.Location = new System.Drawing.Point(142, 131);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(66, 20);
            this.txtAccountNo.TabIndex = 15;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(25, 132);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(110, 18);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Account No. Column";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(63, 76);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(72, 18);
            this.radLabel2.TabIndex = 13;
            this.radLabel2.Text = "Business Line";
            // 
            // ddlBusinessLine
            // 
            this.ddlBusinessLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBusinessLine.DataSource = this.bindingSourceBusinessLine;
            this.ddlBusinessLine.DisplayMember = "BusinessLineDescription";
            this.ddlBusinessLine.Location = new System.Drawing.Point(142, 76);
            this.ddlBusinessLine.Name = "ddlBusinessLine";
            this.ddlBusinessLine.Size = new System.Drawing.Size(293, 20);
            this.ddlBusinessLine.TabIndex = 12;
            this.ddlBusinessLine.ValueMember = "BusinessLineId";
            // 
            // rbeFile
            // 
            this.rbeFile.Location = new System.Drawing.Point(142, 19);
            this.rbeFile.Name = "rbeFile";
            this.rbeFile.Size = new System.Drawing.Size(293, 20);
            this.rbeFile.TabIndex = 11;
            this.rbeFile.ValueChanged += new System.EventHandler(this.rbeFile_ValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(112, 20);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(23, 18);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "File";
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(29, 236);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(87, 28);
            this.BtnImport.TabIndex = 1;
            this.BtnImport.Text = "Import File";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(119, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BgwFileImport
            // 
            this.BgwFileImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwFileImport_DoWork);
            this.BgwFileImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwFileImport_RunWorkerCompleted);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(88, 104);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(47, 18);
            this.radLabel7.TabIndex = 25;
            this.radLabel7.Text = "Region\r\n";
            // 
            // ddlRegion
            // 
            this.ddlRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRegion.DataSource = this.bindingSourceRegion;
            this.ddlRegion.DisplayMember = "RegionDescription";
            this.ddlRegion.Location = new System.Drawing.Point(142, 104);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.Size = new System.Drawing.Size(293, 20);
            this.ddlRegion.TabIndex = 24;
            this.ddlRegion.ValueMember = "RegionId";
            // 
            // bindingSourceBusinessLine
            // 
            this.bindingSourceBusinessLine.DataSource = typeof(SmartReconciliator.CM_BusinessLine);
            // 
            // bindingSourceRegion
            // 
            this.bindingSourceRegion.DataSource = typeof(SmartReconciliator.RegionView);
            // 
            // bindingSourcePeriod
            // 
            this.bindingSourcePeriod.DataSource = typeof(SmartReconciliator.ApplicationUtil.payPeriodDefinition);
            // 
            // bindingSourceSheet
            // 
            this.bindingSourceSheet.DataSource = typeof(SmartReconciliator.ApplicationUtil.workSheetDefinition);
            // 
            // FrmFileImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 276);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileImport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "File Import";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileImport_FormClosing);
            this.Load += new System.EventHandler(this.FrmFileImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWorkSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinStartRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBusinessLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbeFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBusinessLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadDropDownList ddlWorkSheet;
        private Telerik.WinControls.UI.RadSpinEditor spinStartRow;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtAccountNo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlBusinessLine;
        private Telerik.WinControls.UI.RadBrowseEditor rbeFile;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton BtnImport;
        private Telerik.WinControls.UI.RadButton btnClose;
        private System.ComponentModel.BackgroundWorker BgwFileImport;
        private System.Windows.Forms.BindingSource bindingSourceSheet;
        private System.Windows.Forms.BindingSource bindingSourcePeriod;
        private Telerik.WinControls.UI.RadTextBox txtTransDate;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private System.Windows.Forms.BindingSource bindingSourceBusinessLine;
        private System.Windows.Forms.BindingSource bindingSourceRegion;
    }
}
