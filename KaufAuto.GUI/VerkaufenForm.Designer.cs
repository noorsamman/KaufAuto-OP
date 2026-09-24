namespace KaufAuto.GUI
{
    partial class VerkaufenForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        private void InitializeComponent()
        {
            this.lblAuto = new System.Windows.Forms.Label();
            this.lblKaeufer = new System.Windows.Forms.Label();
            this.txtKaeufer = new System.Windows.Forms.TextBox();
            this.lblPreis = new System.Windows.Forms.Label();
            this.nudPreis = new System.Windows.Forms.NumericUpDown();
            this.lblRabatt = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreis)).BeginInit();
            this.SuspendLayout();
            //
            // lblAuto
            //
            this.lblAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAuto.Location = new System.Drawing.Point(20, 15);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(340, 40);
            this.lblAuto.TabIndex = 0;
            this.lblAuto.Text = "Auto";
            //
            // lblKaeufer
            //
            this.lblKaeufer.AutoSize = true;
            this.lblKaeufer.Location = new System.Drawing.Point(20, 71);
            this.lblKaeufer.Name = "lblKaeufer";
            this.lblKaeufer.Size = new System.Drawing.Size(47, 15);
            this.lblKaeufer.TabIndex = 1;
            this.lblKaeufer.Text = "Käufer:";
            //
            // txtKaeufer
            //
            this.txtKaeufer.Location = new System.Drawing.Point(150, 68);
            this.txtKaeufer.Name = "txtKaeufer";
            this.txtKaeufer.Size = new System.Drawing.Size(200, 23);
            this.txtKaeufer.TabIndex = 2;
            //
            // lblPreis
            //
            this.lblPreis.AutoSize = true;
            this.lblPreis.Location = new System.Drawing.Point(20, 107);
            this.lblPreis.Name = "lblPreis";
            this.lblPreis.Size = new System.Drawing.Size(107, 15);
            this.lblPreis.TabIndex = 3;
            this.lblPreis.Text = "Verkaufspreis (€):";
            //
            // nudPreis
            //
            this.nudPreis.DecimalPlaces = 2;
            this.nudPreis.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPreis.Location = new System.Drawing.Point(150, 104);
            this.nudPreis.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPreis.Name = "nudPreis";
            this.nudPreis.Size = new System.Drawing.Size(200, 23);
            this.nudPreis.TabIndex = 4;
            this.nudPreis.ThousandsSeparator = true;
            this.nudPreis.ValueChanged += new System.EventHandler(this.nudPreis_ValueChanged);
            //
            // lblRabatt
            //
            this.lblRabatt.AutoSize = true;
            this.lblRabatt.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblRabatt.Location = new System.Drawing.Point(150, 135);
            this.lblRabatt.Name = "lblRabatt";
            this.lblRabatt.Size = new System.Drawing.Size(0, 15);
            this.lblRabatt.TabIndex = 5;
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(150, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 30);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Verkaufen";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.Location = new System.Drawing.Point(255, 170);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(95, 30);
            this.btnAbbrechen.TabIndex = 7;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            //
            // VerkaufenForm
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(374, 220);
            this.Controls.Add(this.lblAuto);
            this.Controls.Add(this.lblKaeufer);
            this.Controls.Add(this.txtKaeufer);
            this.Controls.Add(this.lblPreis);
            this.Controls.Add(this.nudPreis);
            this.Controls.Add(this.lblRabatt);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAbbrechen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerkaufenForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto verkaufen";
            ((System.ComponentModel.ISupportInitialize)(this.nudPreis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Label lblKaeufer;
        private System.Windows.Forms.TextBox txtKaeufer;
        private System.Windows.Forms.Label lblPreis;
        private System.Windows.Forms.NumericUpDown nudPreis;
        private System.Windows.Forms.Label lblRabatt;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAbbrechen;
    }
}
