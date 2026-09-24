namespace KaufAuto.GUI
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle stylKm = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stylPreis = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblUntertitel = new System.Windows.Forms.Label();
            this.pnlOben = new System.Windows.Forms.Panel();
            this.lblSuche = new System.Windows.Forms.Label();
            this.txtSuche = new System.Windows.Forms.TextBox();
            this.lblKraftstoff = new System.Windows.Forms.Label();
            this.cmbKraftstoff = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dgvAutos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaujahr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKraftstoff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGetriebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZustand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlUnten = new System.Windows.Forms.Panel();
            this.btnHinzufuegen = new System.Windows.Forms.Button();
            this.btnBearbeiten = new System.Windows.Forms.Button();
            this.btnLoeschen = new System.Windows.Forms.Button();
            this.btnVerkaufen = new System.Windows.Forms.Button();
            this.btnFinanzierung = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).BeginInit();
            this.pnlUnten.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblTitel);
            this.pnlHeader.Controls.Add(this.lblUntertitel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1084, 64);
            this.pnlHeader.TabIndex = 4;
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTitel.ForeColor = System.Drawing.Color.White;
            this.lblTitel.Location = new System.Drawing.Point(16, 14);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(140, 30);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "KaufAuto OP";
            //
            // lblUntertitel
            //
            this.lblUntertitel.AutoSize = true;
            this.lblUntertitel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUntertitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUntertitel.Location = new System.Drawing.Point(160, 23);
            this.lblUntertitel.Name = "lblUntertitel";
            this.lblUntertitel.Size = new System.Drawing.Size(210, 19);
            this.lblUntertitel.TabIndex = 1;
            this.lblUntertitel.Text = "Fahrzeugverwaltung & Verkauf";
            this.lblUntertitel.UseMnemonic = false;
            //
            // pnlOben
            //
            this.pnlOben.Controls.Add(this.lblSuche);
            this.pnlOben.Controls.Add(this.txtSuche);
            this.pnlOben.Controls.Add(this.lblKraftstoff);
            this.pnlOben.Controls.Add(this.cmbKraftstoff);
            this.pnlOben.Controls.Add(this.lblStatus);
            this.pnlOben.Controls.Add(this.cmbStatus);
            this.pnlOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOben.Location = new System.Drawing.Point(0, 0);
            this.pnlOben.Name = "pnlOben";
            this.pnlOben.Size = new System.Drawing.Size(1084, 50);
            this.pnlOben.TabIndex = 0;
            //
            // lblSuche
            //
            this.lblSuche.AutoSize = true;
            this.lblSuche.Location = new System.Drawing.Point(12, 16);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Size = new System.Drawing.Size(128, 15);
            this.lblSuche.TabIndex = 0;
            this.lblSuche.Text = "Suche (Marke/Modell):";
            //
            // txtSuche
            //
            this.txtSuche.Location = new System.Drawing.Point(150, 13);
            this.txtSuche.Name = "txtSuche";
            this.txtSuche.Size = new System.Drawing.Size(200, 23);
            this.txtSuche.TabIndex = 1;
            this.txtSuche.TextChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblKraftstoff
            //
            this.lblKraftstoff.AutoSize = true;
            this.lblKraftstoff.Location = new System.Drawing.Point(375, 16);
            this.lblKraftstoff.Name = "lblKraftstoff";
            this.lblKraftstoff.Size = new System.Drawing.Size(61, 15);
            this.lblKraftstoff.TabIndex = 2;
            this.lblKraftstoff.Text = "Kraftstoff:";
            //
            // cmbKraftstoff
            //
            this.cmbKraftstoff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKraftstoff.Items.AddRange(new object[] {
            "Alle",
            "Benzin",
            "Diesel",
            "Elektro",
            "Hybrid"});
            this.cmbKraftstoff.Location = new System.Drawing.Point(442, 13);
            this.cmbKraftstoff.Name = "cmbKraftstoff";
            this.cmbKraftstoff.Size = new System.Drawing.Size(110, 23);
            this.cmbKraftstoff.TabIndex = 3;
            this.cmbKraftstoff.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(575, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            //
            // cmbStatus
            //
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Alle",
            "Verfügbar",
            "Verkauft"});
            this.cmbStatus.Location = new System.Drawing.Point(623, 13);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(110, 23);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // dgvAutos
            //
            this.dgvAutos.AllowUserToAddRows = false;
            this.dgvAutos.AllowUserToDeleteRows = false;
            this.dgvAutos.AllowUserToResizeRows = false;
            this.dgvAutos.AutoGenerateColumns = false;
            this.dgvAutos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTyp,
            this.colMarke,
            this.colModell,
            this.colBaujahr,
            this.colPS,
            this.colKm,
            this.colKraftstoff,
            this.colGetriebe,
            this.colZustand,
            this.colPreis,
            this.colStatus});
            this.dgvAutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAutos.Location = new System.Drawing.Point(0, 50);
            this.dgvAutos.MultiSelect = false;
            this.dgvAutos.Name = "dgvAutos";
            this.dgvAutos.ReadOnly = true;
            this.dgvAutos.RowHeadersVisible = false;
            this.dgvAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutos.Size = new System.Drawing.Size(1084, 433);
            this.dgvAutos.TabIndex = 1;
            this.dgvAutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutos_CellDoubleClick);
            this.dgvAutos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAutos_DataBindingComplete);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 45;
            //
            // colTyp
            //
            this.colTyp.DataPropertyName = "Fahrzeugtyp";
            this.colTyp.HeaderText = "Typ";
            this.colTyp.Name = "colTyp";
            this.colTyp.ReadOnly = true;
            this.colTyp.Width = 85;
            //
            // colMarke
            //
            this.colMarke.DataPropertyName = "Marke";
            this.colMarke.HeaderText = "Marke";
            this.colMarke.Name = "colMarke";
            this.colMarke.ReadOnly = true;
            //
            // colModell
            //
            this.colModell.DataPropertyName = "Modell";
            this.colModell.HeaderText = "Modell";
            this.colModell.Name = "colModell";
            this.colModell.ReadOnly = true;
            this.colModell.Width = 110;
            //
            // colBaujahr
            //
            this.colBaujahr.DataPropertyName = "Baujahr";
            this.colBaujahr.HeaderText = "Baujahr";
            this.colBaujahr.Name = "colBaujahr";
            this.colBaujahr.ReadOnly = true;
            this.colBaujahr.Width = 65;
            //
            // colPS
            //
            this.colPS.DataPropertyName = "MotorleistungPS";
            this.colPS.HeaderText = "PS";
            this.colPS.Name = "colPS";
            this.colPS.ReadOnly = true;
            this.colPS.Width = 55;
            //
            // colKm
            //
            stylKm.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stylKm.Format = "N0";
            this.colKm.DataPropertyName = "Kilometerstand";
            this.colKm.DefaultCellStyle = stylKm;
            this.colKm.HeaderText = "Kilometer";
            this.colKm.Name = "colKm";
            this.colKm.ReadOnly = true;
            this.colKm.Width = 85;
            //
            // colKraftstoff
            //
            this.colKraftstoff.DataPropertyName = "Kraftstoff";
            this.colKraftstoff.HeaderText = "Kraftstoff";
            this.colKraftstoff.Name = "colKraftstoff";
            this.colKraftstoff.ReadOnly = true;
            this.colKraftstoff.Width = 80;
            //
            // colGetriebe
            //
            this.colGetriebe.DataPropertyName = "Getriebe";
            this.colGetriebe.HeaderText = "Getriebe";
            this.colGetriebe.Name = "colGetriebe";
            this.colGetriebe.ReadOnly = true;
            this.colGetriebe.Width = 105;
            //
            // colZustand
            //
            this.colZustand.DataPropertyName = "Zustand";
            this.colZustand.HeaderText = "Zustand";
            this.colZustand.Name = "colZustand";
            this.colZustand.ReadOnly = true;
            this.colZustand.Width = 80;
            //
            // colPreis
            //
            stylPreis.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stylPreis.Format = "N2";
            this.colPreis.DataPropertyName = "Preis";
            this.colPreis.DefaultCellStyle = stylPreis;
            this.colPreis.HeaderText = "Preis (€)";
            this.colPreis.Name = "colPreis";
            this.colPreis.ReadOnly = true;
            this.colPreis.Width = 105;
            //
            // colStatus
            //
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            //
            // pnlUnten
            //
            this.pnlUnten.Controls.Add(this.btnHinzufuegen);
            this.pnlUnten.Controls.Add(this.btnBearbeiten);
            this.pnlUnten.Controls.Add(this.btnLoeschen);
            this.pnlUnten.Controls.Add(this.btnVerkaufen);
            this.pnlUnten.Controls.Add(this.btnFinanzierung);
            this.pnlUnten.Controls.Add(this.btnSpeichern);
            this.pnlUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUnten.Location = new System.Drawing.Point(0, 483);
            this.pnlUnten.Name = "pnlUnten";
            this.pnlUnten.Size = new System.Drawing.Size(1084, 56);
            this.pnlUnten.TabIndex = 2;
            //
            // btnHinzufuegen
            //
            this.btnHinzufuegen.Location = new System.Drawing.Point(12, 12);
            this.btnHinzufuegen.Name = "btnHinzufuegen";
            this.btnHinzufuegen.Size = new System.Drawing.Size(115, 32);
            this.btnHinzufuegen.TabIndex = 0;
            this.btnHinzufuegen.Text = "Hinzufügen";
            this.btnHinzufuegen.UseVisualStyleBackColor = true;
            this.btnHinzufuegen.Click += new System.EventHandler(this.btnHinzufuegen_Click);
            //
            // btnBearbeiten
            //
            this.btnBearbeiten.Location = new System.Drawing.Point(133, 12);
            this.btnBearbeiten.Name = "btnBearbeiten";
            this.btnBearbeiten.Size = new System.Drawing.Size(115, 32);
            this.btnBearbeiten.TabIndex = 1;
            this.btnBearbeiten.Text = "Bearbeiten";
            this.btnBearbeiten.UseVisualStyleBackColor = true;
            this.btnBearbeiten.Click += new System.EventHandler(this.btnBearbeiten_Click);
            //
            // btnLoeschen
            //
            this.btnLoeschen.Location = new System.Drawing.Point(254, 12);
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.Size = new System.Drawing.Size(115, 32);
            this.btnLoeschen.TabIndex = 2;
            this.btnLoeschen.Text = "Löschen";
            this.btnLoeschen.UseVisualStyleBackColor = true;
            this.btnLoeschen.Click += new System.EventHandler(this.btnLoeschen_Click);
            //
            // btnVerkaufen
            //
            this.btnVerkaufen.Location = new System.Drawing.Point(375, 12);
            this.btnVerkaufen.Name = "btnVerkaufen";
            this.btnVerkaufen.Size = new System.Drawing.Size(115, 32);
            this.btnVerkaufen.TabIndex = 3;
            this.btnVerkaufen.Text = "Verkaufen";
            this.btnVerkaufen.UseVisualStyleBackColor = true;
            this.btnVerkaufen.Click += new System.EventHandler(this.btnVerkaufen_Click);
            //
            // btnFinanzierung
            //
            this.btnFinanzierung.Location = new System.Drawing.Point(496, 12);
            this.btnFinanzierung.Name = "btnFinanzierung";
            this.btnFinanzierung.Size = new System.Drawing.Size(115, 32);
            this.btnFinanzierung.TabIndex = 4;
            this.btnFinanzierung.Text = "Finanzierung";
            this.btnFinanzierung.UseVisualStyleBackColor = true;
            this.btnFinanzierung.Click += new System.EventHandler(this.btnFinanzierung_Click);
            //
            // btnSpeichern
            //
            this.btnSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeichern.Location = new System.Drawing.Point(957, 12);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(115, 32);
            this.btnSpeichern.TabIndex = 5;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip.TabIndex = 3;
            //
            // lblInfo
            //
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 625);
            this.Controls.Add(this.dgvAutos);
            this.Controls.Add(this.pnlUnten);
            this.Controls.Add(this.pnlOben);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KaufAuto OP – Autoverwaltung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlOben.ResumeLayout(false);
            this.pnlOben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).EndInit();
            this.pnlUnten.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblUntertitel;
        private System.Windows.Forms.Panel pnlOben;
        private System.Windows.Forms.Label lblSuche;
        private System.Windows.Forms.TextBox txtSuche;
        private System.Windows.Forms.Label lblKraftstoff;
        private System.Windows.Forms.ComboBox cmbKraftstoff;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridView dgvAutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarke;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaujahr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKraftstoff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGetriebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZustand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel pnlUnten;
        private System.Windows.Forms.Button btnHinzufuegen;
        private System.Windows.Forms.Button btnBearbeiten;
        private System.Windows.Forms.Button btnLoeschen;
        private System.Windows.Forms.Button btnVerkaufen;
        private System.Windows.Forms.Button btnFinanzierung;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
    }
}
