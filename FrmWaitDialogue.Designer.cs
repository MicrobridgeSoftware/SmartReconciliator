namespace SmartReconciliator
{
    partial class FrmWaitDialogue
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
            this.radWaitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.rotatingRingsWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.RotatingRingsWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radWaitingBar
            // 
            this.radWaitingBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWaitingBar.Location = new System.Drawing.Point(0, 0);
            this.radWaitingBar.Name = "radWaitingBar";
            this.radWaitingBar.ShowText = true;
            this.radWaitingBar.Size = new System.Drawing.Size(292, 134);
            this.radWaitingBar.TabIndex = 0;
            this.radWaitingBar.Text = "Processing. Please wait............";
            this.radWaitingBar.WaitingIndicators.Add(this.rotatingRingsWaitingBarIndicatorElement1);
            this.radWaitingBar.WaitingStep = 7;
            this.radWaitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.RotatingRings;
            // 
            // rotatingRingsWaitingBarIndicatorElement1
            // 
            this.rotatingRingsWaitingBarIndicatorElement1.Name = "rotatingRingsWaitingBarIndicatorElement1";
            // 
            // FrmWaitDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 134);
            this.ControlBox = false;
            this.Controls.Add(this.radWaitingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWaitDialogue";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Wait Dialogue";
            this.Load += new System.EventHandler(this.FrmWaitDialogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar;
        private Telerik.WinControls.UI.RotatingRingsWaitingBarIndicatorElement rotatingRingsWaitingBarIndicatorElement1;
    }
}
