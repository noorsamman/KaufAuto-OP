namespace KaufAuto.GUI
{
    partial class FinanzierungForm
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
            this.lblAnzahlung = new System.Windows.Forms.Label();
            this.nudAnzahlung = new System.Windows.Forms.NumericUpDown();
            this.lblLaufzeit = new System.Windows.Forms.Label();
            this.nudLaufzeit = new System.Windows.Forms.NumericUpDown();
            this.lblZins = new System.Windows.Forms.Label();
            this.nudZins = new System.Windows.Forms.NumericUpDown();
            this.grpErgebnis = new System.Windows.Forms.GroupBox();
            this.lblKreditText = new System.Windows.Forms.Label();
            this.lblKredit = new System.Windows.Forms.Label();
            this.lblRateText = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblZinskostenText = new System.Windows.Forms.Label();
            this.lblZinskosten = new System.Windows.Forms.Label();
            this.lblGesamtText = new System.Windows.Forms.Label();
            this.lblGesamt = new System.Windows.Forms.Label();
            this.btnSchliessen = new KaufAuto.GUI.ModernButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLaufzeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZins)).BeginInit();
            this.grpErgebnis.SuspendLayout();
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
            // lblAnzahlung
            //
            this.lblAnzahlung.AutoSize = true;
            this.lblAnzahlung.Location = new System.Drawing.Point(20, 71);
            this.lblAnzahlung.Name = "lblAnzahlung";
            this.lblAnzahlung.Size = new System.Drawing.Size(92, 15);
            this.lblAnzahlung.TabIndex = 1;
            this.lblAnzahlung.Text = "Anzahlung (€):";
            //
            // nudAnzahlung
            //
            this.nudAnzahlung.DecimalPlaces = 2;
            this.nudAnzahlung.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudAnzahlung.Location = new System.Drawing.Point(160, 68);
            this.nudAnzahlung.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAnzahlung.Name = "nudAnzahlung";
            this.nudAnzahlung.Size = new System.Drawing.Size(190, 23);
            this.nudAnzahlung.TabIndex = 2;
            this.nudAnzahlung.ThousandsSeparator = true;
            this.nudAnzahlung.ValueChanged += new System.EventHandler(this.Eingabe_Changed);
            //
            // lblLaufzeit
            //
            this.lblLaufzeit.AutoSize = true;
            this.lblLaufzeit.Location = new System.Drawing.Point(20, 107);
            this.lblLaufzeit.Name = "lblLaufzeit";
            this.lblLaufzeit.Size = new System.Drawing.Size(119, 15);
            this.lblLaufzeit.TabIndex = 3;
            this.lblLaufzeit.Text = "Laufzeit (Monate):";
            //
            // nudLaufzeit
            //
            this.nudLaufzeit.Increment = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudLaufzeit.Location = new System.Drawing.Point(160, 104);
            this.nudLaufzeit.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.nudLaufzeit.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudLaufzeit.Name = "nudLaufzeit";
            this.nudLaufzeit.Size = new System.Drawing.Size(190, 23);
            this.nudLaufzeit.TabIndex = 4;
            this.nudLaufzeit.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nudLaufzeit.ValueChanged += new System.EventHandler(this.Eingabe_Changed);
            //
            // lblZins
            //
            this.lblZins.AutoSize = true;
            this.lblZins.Location = new System.Drawing.Point(20, 143);
            this.lblZins.Name = "lblZins";
            this.lblZins.Size = new System.Drawing.Size(125, 15);
            this.lblZins.TabIndex = 5;
            this.lblZins.Text = "Zinssatz pro Jahr (%):";
            //
            // nudZins
            //
            this.nudZins.DecimalPlaces = 2;
            this.nudZins.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudZins.Location = new System.Drawing.Point(160, 140);
            this.nudZins.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudZins.Name = "nudZins";
            this.nudZins.Size = new System.Drawing.Size(190, 23);
            this.nudZins.TabIndex = 6;
            this.nudZins.Value = new decimal(new int[] {
            49,
            0,
            0,
            65536});
            this.nudZins.ValueChanged += new System.EventHandler(this.Eingabe_Changed);
            //
            // grpErgebnis
            //
            this.grpErgebnis.Controls.Add(this.lblKreditText);
            this.grpErgebnis.Controls.Add(this.lblKredit);
            this.grpErgebnis.Controls.Add(this.lblRateText);
            this.grpErgebnis.Controls.Add(this.lblRate);
            this.grpErgebnis.Controls.Add(this.lblZinskostenText);
            this.grpErgebnis.Controls.Add(this.lblZinskosten);
            this.grpErgebnis.Controls.Add(this.lblGesamtText);
            this.grpErgebnis.Controls.Add(this.lblGesamt);
            this.grpErgebnis.Location = new System.Drawing.Point(20, 180);
            this.grpErgebnis.Name = "grpErgebnis";
            this.grpErgebnis.Size = new System.Drawing.Size(330, 150);
            this.grpErgebnis.TabIndex = 7;
            this.grpErgebnis.TabStop = false;
            this.grpErgebnis.Text = "Ergebnis";
            //
            // lblKreditText
            //
            this.lblKreditText.AutoSize = true;
            this.lblKreditText.Location = new System.Drawing.Point(15, 28);
            this.lblKreditText.Name = "lblKreditText";
            this.lblKreditText.Size = new System.Drawing.Size(79, 15);
            this.lblKreditText.TabIndex = 0;
            this.lblKreditText.Text = "Kreditbetrag:";
            //
            // lblKredit
            //
            this.lblKredit.Location = new System.Drawing.Point(140, 28);
            this.lblKredit.Name = "lblKredit";
            this.lblKredit.Size = new System.Drawing.Size(175, 15);
            this.lblKredit.TabIndex = 1;
            this.lblKredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblRateText
            //
            this.lblRateText.AutoSize = true;
            this.lblRateText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRateText.Location = new System.Drawing.Point(15, 55);
            this.lblRateText.Name = "lblRateText";
            this.lblRateText.Size = new System.Drawing.Size(99, 20);
            this.lblRateText.TabIndex = 2;
            this.lblRateText.Text = "Monatsrate:";
            //
            // lblRate
            //
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRate.Location = new System.Drawing.Point(140, 55);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(175, 20);
            this.lblRate.TabIndex = 3;
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblZinskostenText
            //
            this.lblZinskostenText.AutoSize = true;
            this.lblZinskostenText.Location = new System.Drawing.Point(15, 88);
            this.lblZinskostenText.Name = "lblZinskostenText";
            this.lblZinskostenText.Size = new System.Drawing.Size(70, 15);
            this.lblZinskostenText.TabIndex = 4;
            this.lblZinskostenText.Text = "Zinskosten:";
            //
            // lblZinskosten
            //
            this.lblZinskosten.Location = new System.Drawing.Point(140, 88);
            this.lblZinskosten.Name = "lblZinskosten";
            this.lblZinskosten.Size = new System.Drawing.Size(175, 15);
            this.lblZinskosten.TabIndex = 5;
            this.lblZinskosten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblGesamtText
            //
            this.lblGesamtText.AutoSize = true;
            this.lblGesamtText.Location = new System.Drawing.Point(15, 116);
            this.lblGesamtText.Name = "lblGesamtText";
            this.lblGesamtText.Size = new System.Drawing.Size(82, 15);
            this.lblGesamtText.TabIndex = 6;
            this.lblGesamtText.Text = "Gesamtkosten:";
            //
            // lblGesamt
            //
            this.lblGesamt.Location = new System.Drawing.Point(140, 116);
            this.lblGesamt.Name = "lblGesamt";
            this.lblGesamt.Size = new System.Drawing.Size(175, 15);
            this.lblGesamt.TabIndex = 7;
            this.lblGesamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnSchliessen
            //
            this.btnSchliessen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSchliessen.Location = new System.Drawing.Point(255, 345);
            this.btnSchliessen.Name = "btnSchliessen";
            this.btnSchliessen.Size = new System.Drawing.Size(95, 30);
            this.btnSchliessen.TabIndex = 8;
            this.btnSchliessen.Text = "Schließen";
            this.btnSchliessen.UseVisualStyleBackColor = true;
            //
            // FinanzierungForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSchliessen;
            this.ClientSize = new System.Drawing.Size(374, 390);
            this.Controls.Add(this.lblAuto);
            this.Controls.Add(this.lblAnzahlung);
            this.Controls.Add(this.nudAnzahlung);
            this.Controls.Add(this.lblLaufzeit);
            this.Controls.Add(this.nudLaufzeit);
            this.Controls.Add(this.lblZins);
            this.Controls.Add(this.nudZins);
            this.Controls.Add(this.grpErgebnis);
            this.Controls.Add(this.btnSchliessen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinanzierungForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finanzierung berechnen";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLaufzeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZins)).EndInit();
            this.grpErgebnis.ResumeLayout(false);
            this.grpErgebnis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Label lblAnzahlung;
        private System.Windows.Forms.NumericUpDown nudAnzahlung;
        private System.Windows.Forms.Label lblLaufzeit;
        private System.Windows.Forms.NumericUpDown nudLaufzeit;
        private System.Windows.Forms.Label lblZins;
        private System.Windows.Forms.NumericUpDown nudZins;
        private System.Windows.Forms.GroupBox grpErgebnis;
        private System.Windows.Forms.Label lblKreditText;
        private System.Windows.Forms.Label lblKredit;
        private System.Windows.Forms.Label lblRateText;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblZinskostenText;
        private System.Windows.Forms.Label lblZinskosten;
        private System.Windows.Forms.Label lblGesamtText;
        private System.Windows.Forms.Label lblGesamt;
        private KaufAuto.GUI.ModernButton btnSchliessen;
    }
}
