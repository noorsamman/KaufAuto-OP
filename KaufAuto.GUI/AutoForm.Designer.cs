namespace KaufAuto.GUI
{
    partial class AutoForm
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
            this.lblTyp = new System.Windows.Forms.Label();
            this.cmbTyp = new System.Windows.Forms.ComboBox();
            this.lblMarke = new System.Windows.Forms.Label();
            this.txtMarke = new System.Windows.Forms.TextBox();
            this.lblModell = new System.Windows.Forms.Label();
            this.txtModell = new System.Windows.Forms.TextBox();
            this.lblPS = new System.Windows.Forms.Label();
            this.nudPS = new System.Windows.Forms.NumericUpDown();
            this.lblGetriebe = new System.Windows.Forms.Label();
            this.cmbGetriebe = new System.Windows.Forms.ComboBox();
            this.lblKraftstoff = new System.Windows.Forms.Label();
            this.cmbKraftstoff = new System.Windows.Forms.ComboBox();
            this.lblPreis = new System.Windows.Forms.Label();
            this.nudPreis = new System.Windows.Forms.NumericUpDown();
            this.lblBaujahr = new System.Windows.Forms.Label();
            this.nudBaujahr = new System.Windows.Forms.NumericUpDown();
            this.lblZustand = new System.Windows.Forms.Label();
            this.cmbZustand = new System.Windows.Forms.ComboBox();
            this.lblKm = new System.Windows.Forms.Label();
            this.nudKm = new System.Windows.Forms.NumericUpDown();
            this.lblTueren = new System.Windows.Forms.Label();
            this.nudTueren = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaujahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTueren)).BeginInit();
            this.SuspendLayout();
            //
            // lblTyp
            //
            this.lblTyp.AutoSize = true;
            this.lblTyp.Location = new System.Drawing.Point(20, 23);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(80, 15);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Fahrzeugtyp:";
            //
            // cmbTyp
            //
            this.cmbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTyp.Items.AddRange(new object[] {
            "PKW",
            "SUV",
            "Transporter"});
            this.cmbTyp.Location = new System.Drawing.Point(150, 20);
            this.cmbTyp.Name = "cmbTyp";
            this.cmbTyp.Size = new System.Drawing.Size(200, 23);
            this.cmbTyp.TabIndex = 1;
            //
            // lblMarke
            //
            this.lblMarke.AutoSize = true;
            this.lblMarke.Location = new System.Drawing.Point(20, 59);
            this.lblMarke.Name = "lblMarke";
            this.lblMarke.Size = new System.Drawing.Size(43, 15);
            this.lblMarke.TabIndex = 2;
            this.lblMarke.Text = "Marke:";
            //
            // txtMarke
            //
            this.txtMarke.Location = new System.Drawing.Point(150, 56);
            this.txtMarke.Name = "txtMarke";
            this.txtMarke.Size = new System.Drawing.Size(200, 23);
            this.txtMarke.TabIndex = 3;
            //
            // lblModell
            //
            this.lblModell.AutoSize = true;
            this.lblModell.Location = new System.Drawing.Point(20, 95);
            this.lblModell.Name = "lblModell";
            this.lblModell.Size = new System.Drawing.Size(47, 15);
            this.lblModell.TabIndex = 4;
            this.lblModell.Text = "Modell:";
            //
            // txtModell
            //
            this.txtModell.Location = new System.Drawing.Point(150, 92);
            this.txtModell.Name = "txtModell";
            this.txtModell.Size = new System.Drawing.Size(200, 23);
            this.txtModell.TabIndex = 5;
            //
            // lblPS
            //
            this.lblPS.AutoSize = true;
            this.lblPS.Location = new System.Drawing.Point(20, 131);
            this.lblPS.Name = "lblPS";
            this.lblPS.Size = new System.Drawing.Size(22, 15);
            this.lblPS.TabIndex = 6;
            this.lblPS.Text = "PS:";
            //
            // nudPS
            //
            this.nudPS.Location = new System.Drawing.Point(150, 128);
            this.nudPS.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPS.Name = "nudPS";
            this.nudPS.Size = new System.Drawing.Size(200, 23);
            this.nudPS.TabIndex = 7;
            this.nudPS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // lblGetriebe
            //
            this.lblGetriebe.AutoSize = true;
            this.lblGetriebe.Location = new System.Drawing.Point(20, 167);
            this.lblGetriebe.Name = "lblGetriebe";
            this.lblGetriebe.Size = new System.Drawing.Size(56, 15);
            this.lblGetriebe.TabIndex = 8;
            this.lblGetriebe.Text = "Getriebe:";
            //
            // cmbGetriebe
            //
            this.cmbGetriebe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGetriebe.Items.AddRange(new object[] {
            "Automatik",
            "Schaltgetriebe"});
            this.cmbGetriebe.Location = new System.Drawing.Point(150, 164);
            this.cmbGetriebe.Name = "cmbGetriebe";
            this.cmbGetriebe.Size = new System.Drawing.Size(200, 23);
            this.cmbGetriebe.TabIndex = 9;
            //
            // lblKraftstoff
            //
            this.lblKraftstoff.AutoSize = true;
            this.lblKraftstoff.Location = new System.Drawing.Point(20, 203);
            this.lblKraftstoff.Name = "lblKraftstoff";
            this.lblKraftstoff.Size = new System.Drawing.Size(61, 15);
            this.lblKraftstoff.TabIndex = 10;
            this.lblKraftstoff.Text = "Kraftstoff:";
            //
            // cmbKraftstoff
            //
            this.cmbKraftstoff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKraftstoff.Items.AddRange(new object[] {
            "Benzin",
            "Diesel",
            "Elektro",
            "Hybrid"});
            this.cmbKraftstoff.Location = new System.Drawing.Point(150, 200);
            this.cmbKraftstoff.Name = "cmbKraftstoff";
            this.cmbKraftstoff.Size = new System.Drawing.Size(200, 23);
            this.cmbKraftstoff.TabIndex = 11;
            //
            // lblPreis
            //
            this.lblPreis.AutoSize = true;
            this.lblPreis.Location = new System.Drawing.Point(20, 239);
            this.lblPreis.Name = "lblPreis";
            this.lblPreis.Size = new System.Drawing.Size(55, 15);
            this.lblPreis.TabIndex = 12;
            this.lblPreis.Text = "Preis (€):";
            //
            // nudPreis
            //
            this.nudPreis.DecimalPlaces = 2;
            this.nudPreis.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudPreis.Location = new System.Drawing.Point(150, 236);
            this.nudPreis.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPreis.Name = "nudPreis";
            this.nudPreis.Size = new System.Drawing.Size(200, 23);
            this.nudPreis.TabIndex = 13;
            this.nudPreis.ThousandsSeparator = true;
            //
            // lblBaujahr
            //
            this.lblBaujahr.AutoSize = true;
            this.lblBaujahr.Location = new System.Drawing.Point(20, 275);
            this.lblBaujahr.Name = "lblBaujahr";
            this.lblBaujahr.Size = new System.Drawing.Size(50, 15);
            this.lblBaujahr.TabIndex = 14;
            this.lblBaujahr.Text = "Baujahr:";
            //
            // nudBaujahr
            //
            this.nudBaujahr.Location = new System.Drawing.Point(150, 272);
            this.nudBaujahr.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudBaujahr.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nudBaujahr.Name = "nudBaujahr";
            this.nudBaujahr.Size = new System.Drawing.Size(200, 23);
            this.nudBaujahr.TabIndex = 15;
            this.nudBaujahr.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            //
            // lblZustand
            //
            this.lblZustand.AutoSize = true;
            this.lblZustand.Location = new System.Drawing.Point(20, 311);
            this.lblZustand.Name = "lblZustand";
            this.lblZustand.Size = new System.Drawing.Size(53, 15);
            this.lblZustand.TabIndex = 16;
            this.lblZustand.Text = "Zustand:";
            //
            // cmbZustand
            //
            this.cmbZustand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZustand.Items.AddRange(new object[] {
            "Neu",
            "Gebraucht"});
            this.cmbZustand.Location = new System.Drawing.Point(150, 308);
            this.cmbZustand.Name = "cmbZustand";
            this.cmbZustand.Size = new System.Drawing.Size(200, 23);
            this.cmbZustand.TabIndex = 17;
            this.cmbZustand.SelectedIndexChanged += new System.EventHandler(this.cmbZustand_SelectedIndexChanged);
            //
            // lblKm
            //
            this.lblKm.AutoSize = true;
            this.lblKm.Location = new System.Drawing.Point(20, 347);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(92, 15);
            this.lblKm.TabIndex = 18;
            this.lblKm.Text = "Kilometerstand:";
            //
            // nudKm
            //
            this.nudKm.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudKm.Location = new System.Drawing.Point(150, 344);
            this.nudKm.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudKm.Name = "nudKm";
            this.nudKm.Size = new System.Drawing.Size(200, 23);
            this.nudKm.TabIndex = 19;
            this.nudKm.ThousandsSeparator = true;
            //
            // lblTueren
            //
            this.lblTueren.AutoSize = true;
            this.lblTueren.Location = new System.Drawing.Point(20, 383);
            this.lblTueren.Name = "lblTueren";
            this.lblTueren.Size = new System.Drawing.Size(40, 15);
            this.lblTueren.TabIndex = 20;
            this.lblTueren.Text = "Türen:";
            //
            // nudTueren
            //
            this.nudTueren.Location = new System.Drawing.Point(150, 380);
            this.nudTueren.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTueren.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTueren.Name = "nudTueren";
            this.nudTueren.Size = new System.Drawing.Size(200, 23);
            this.nudTueren.TabIndex = 21;
            this.nudTueren.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(150, 425);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 30);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Speichern";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.Location = new System.Drawing.Point(255, 425);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(95, 30);
            this.btnAbbrechen.TabIndex = 23;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            //
            // AutoForm
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(374, 475);
            this.Controls.Add(this.lblTyp);
            this.Controls.Add(this.cmbTyp);
            this.Controls.Add(this.lblMarke);
            this.Controls.Add(this.txtMarke);
            this.Controls.Add(this.lblModell);
            this.Controls.Add(this.txtModell);
            this.Controls.Add(this.lblPS);
            this.Controls.Add(this.nudPS);
            this.Controls.Add(this.lblGetriebe);
            this.Controls.Add(this.cmbGetriebe);
            this.Controls.Add(this.lblKraftstoff);
            this.Controls.Add(this.cmbKraftstoff);
            this.Controls.Add(this.lblPreis);
            this.Controls.Add(this.nudPreis);
            this.Controls.Add(this.lblBaujahr);
            this.Controls.Add(this.nudBaujahr);
            this.Controls.Add(this.lblZustand);
            this.Controls.Add(this.cmbZustand);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.nudKm);
            this.Controls.Add(this.lblTueren);
            this.Controls.Add(this.nudTueren);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAbbrechen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto";
            ((System.ComponentModel.ISupportInitialize)(this.nudPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaujahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTueren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.ComboBox cmbTyp;
        private System.Windows.Forms.Label lblMarke;
        private System.Windows.Forms.TextBox txtMarke;
        private System.Windows.Forms.Label lblModell;
        private System.Windows.Forms.TextBox txtModell;
        private System.Windows.Forms.Label lblPS;
        private System.Windows.Forms.NumericUpDown nudPS;
        private System.Windows.Forms.Label lblGetriebe;
        private System.Windows.Forms.ComboBox cmbGetriebe;
        private System.Windows.Forms.Label lblKraftstoff;
        private System.Windows.Forms.ComboBox cmbKraftstoff;
        private System.Windows.Forms.Label lblPreis;
        private System.Windows.Forms.NumericUpDown nudPreis;
        private System.Windows.Forms.Label lblBaujahr;
        private System.Windows.Forms.NumericUpDown nudBaujahr;
        private System.Windows.Forms.Label lblZustand;
        private System.Windows.Forms.ComboBox cmbZustand;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.NumericUpDown nudKm;
        private System.Windows.Forms.Label lblTueren;
        private System.Windows.Forms.NumericUpDown nudTueren;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAbbrechen;
    }
}
