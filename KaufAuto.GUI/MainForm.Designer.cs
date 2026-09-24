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
            this.lblDatum = new System.Windows.Forms.Label();
            this.pnlKarten = new System.Windows.Forms.FlowLayoutPanel();
            this.kpiVerfuegbar = new KaufAuto.GUI.KennzahlKarte();
            this.kpiBestand = new KaufAuto.GUI.KennzahlKarte();
            this.kpiVerkauft = new KaufAuto.GUI.KennzahlKarte();
            this.kpiUmsatz = new KaufAuto.GUI.KennzahlKarte();
            this.pnlOben = new System.Windows.Forms.Panel();
            this.lblSuche = new System.Windows.Forms.Label();
            this.txtSuche = new System.Windows.Forms.TextBox();
            this.lblKraftstoff = new System.Windows.Forms.Label();
            this.cmbKraftstoff = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.pnlTabelle = new System.Windows.Forms.Panel();
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
            this.btnHinzufuegen = new KaufAuto.GUI.ModernButton();
            this.btnBearbeiten = new KaufAuto.GUI.ModernButton();
            this.btnLoeschen = new KaufAuto.GUI.ModernButton();
            this.btnVerkaufen = new KaufAuto.GUI.ModernButton();
            this.btnFinanzierung = new KaufAuto.GUI.ModernButton();
            this.btnSpeichern = new KaufAuto.GUI.ModernButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlKarten.SuspendLayout();
            this.pnlOben.SuspendLayout();
            this.pnlTabelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).BeginInit();
            this.pnlUnten.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblTitel);
            this.pnlHeader.Controls.Add(this.lblUntertitel);
            this.pnlHeader.Controls.Add(this.lblDatum);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 84);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTitel.Location = new System.Drawing.Point(22, 12);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(172, 32);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "KAUFAUTO OP";
            //
            // lblUntertitel
            //
            this.lblUntertitel.AutoSize = true;
            this.lblUntertitel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUntertitel.Location = new System.Drawing.Point(25, 48);
            this.lblUntertitel.Name = "lblUntertitel";
            this.lblUntertitel.Size = new System.Drawing.Size(252, 17);
            this.lblUntertitel.TabIndex = 1;
            this.lblUntertitel.Text = "Premium Fahrzeugverwaltung & Verkauf";
            this.lblUntertitel.UseMnemonic = false;
            //
            // lblDatum
            //
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatum.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDatum.Location = new System.Drawing.Point(856, 30);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(300, 20);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // pnlKarten
            //
            this.pnlKarten.Controls.Add(this.kpiVerfuegbar);
            this.pnlKarten.Controls.Add(this.kpiBestand);
            this.pnlKarten.Controls.Add(this.kpiVerkauft);
            this.pnlKarten.Controls.Add(this.kpiUmsatz);
            this.pnlKarten.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKarten.Location = new System.Drawing.Point(0, 84);
            this.pnlKarten.Name = "pnlKarten";
            this.pnlKarten.Padding = new System.Windows.Forms.Padding(20, 12, 20, 4);
            this.pnlKarten.Size = new System.Drawing.Size(1180, 116);
            this.pnlKarten.TabIndex = 1;
            this.pnlKarten.WrapContents = false;
            //
            // kpiVerfuegbar
            //
            this.kpiVerfuegbar.Margin = new System.Windows.Forms.Padding(4, 4, 12, 4);
            this.kpiVerfuegbar.Name = "kpiVerfuegbar";
            this.kpiVerfuegbar.Size = new System.Drawing.Size(262, 92);
            this.kpiVerfuegbar.TabIndex = 0;
            this.kpiVerfuegbar.Titel = "VERFÜGBAR";
            this.kpiVerfuegbar.Wert = "0";
            this.kpiVerfuegbar.Zusatz = "Fahrzeuge im Bestand";
            //
            // kpiBestand
            //
            this.kpiBestand.Margin = new System.Windows.Forms.Padding(4, 4, 12, 4);
            this.kpiBestand.Name = "kpiBestand";
            this.kpiBestand.Size = new System.Drawing.Size(262, 92);
            this.kpiBestand.TabIndex = 1;
            this.kpiBestand.Titel = "BESTANDSWERT";
            this.kpiBestand.Wert = "0 €";
            this.kpiBestand.Zusatz = "Summe der Listenpreise";
            //
            // kpiVerkauft
            //
            this.kpiVerkauft.Margin = new System.Windows.Forms.Padding(4, 4, 12, 4);
            this.kpiVerkauft.Name = "kpiVerkauft";
            this.kpiVerkauft.Size = new System.Drawing.Size(262, 92);
            this.kpiVerkauft.TabIndex = 2;
            this.kpiVerkauft.Titel = "VERKAUFT";
            this.kpiVerkauft.Wert = "0";
            this.kpiVerkauft.Zusatz = "Fahrzeuge";
            //
            // kpiUmsatz
            //
            this.kpiUmsatz.Margin = new System.Windows.Forms.Padding(4, 4, 12, 4);
            this.kpiUmsatz.Name = "kpiUmsatz";
            this.kpiUmsatz.Size = new System.Drawing.Size(262, 92);
            this.kpiUmsatz.TabIndex = 3;
            this.kpiUmsatz.Titel = "UMSATZ";
            this.kpiUmsatz.Wert = "0 €";
            this.kpiUmsatz.Zusatz = "aus allen Verkäufen";
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
            this.pnlOben.Location = new System.Drawing.Point(0, 200);
            this.pnlOben.Name = "pnlOben";
            this.pnlOben.Size = new System.Drawing.Size(1180, 58);
            this.pnlOben.TabIndex = 2;
            //
            // lblSuche
            //
            this.lblSuche.AutoSize = true;
            this.lblSuche.Location = new System.Drawing.Point(24, 21);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Size = new System.Drawing.Size(40, 17);
            this.lblSuche.TabIndex = 0;
            this.lblSuche.Text = "Suche";
            //
            // txtSuche
            //
            this.txtSuche.Location = new System.Drawing.Point(80, 18);
            this.txtSuche.Name = "txtSuche";
            this.txtSuche.Size = new System.Drawing.Size(240, 24);
            this.txtSuche.TabIndex = 1;
            this.txtSuche.TextChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblKraftstoff
            //
            this.lblKraftstoff.AutoSize = true;
            this.lblKraftstoff.Location = new System.Drawing.Point(350, 21);
            this.lblKraftstoff.Name = "lblKraftstoff";
            this.lblKraftstoff.Size = new System.Drawing.Size(62, 17);
            this.lblKraftstoff.TabIndex = 2;
            this.lblKraftstoff.Text = "Kraftstoff";
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
            this.cmbKraftstoff.Location = new System.Drawing.Point(425, 17);
            this.cmbKraftstoff.Name = "cmbKraftstoff";
            this.cmbKraftstoff.Size = new System.Drawing.Size(130, 25);
            this.cmbKraftstoff.TabIndex = 3;
            this.cmbKraftstoff.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(585, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            //
            // cmbStatus
            //
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Alle",
            "Verfügbar",
            "Verkauft"});
            this.cmbStatus.Location = new System.Drawing.Point(640, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 25);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // pnlTabelle
            //
            this.pnlTabelle.Controls.Add(this.dgvAutos);
            this.pnlTabelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabelle.Location = new System.Drawing.Point(0, 258);
            this.pnlTabelle.Name = "pnlTabelle";
            this.pnlTabelle.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.pnlTabelle.Size = new System.Drawing.Size(1180, 350);
            this.pnlTabelle.TabIndex = 3;
            //
            // dgvAutos
            //
            this.dgvAutos.AllowUserToAddRows = false;
            this.dgvAutos.AllowUserToDeleteRows = false;
            this.dgvAutos.AllowUserToResizeRows = false;
            this.dgvAutos.AutoGenerateColumns = false;
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
            this.dgvAutos.Location = new System.Drawing.Point(24, 0);
            this.dgvAutos.MultiSelect = false;
            this.dgvAutos.Name = "dgvAutos";
            this.dgvAutos.ReadOnly = true;
            this.dgvAutos.RowHeadersVisible = false;
            this.dgvAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutos.Size = new System.Drawing.Size(1132, 350);
            this.dgvAutos.TabIndex = 0;
            this.dgvAutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutos_CellDoubleClick);
            this.dgvAutos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAutos_CellFormatting);
            this.dgvAutos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAutos_DataBindingComplete);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            //
            // colTyp
            //
            this.colTyp.DataPropertyName = "Fahrzeugtyp";
            this.colTyp.HeaderText = "Typ";
            this.colTyp.Name = "colTyp";
            this.colTyp.ReadOnly = true;
            this.colTyp.Width = 100;
            //
            // colMarke
            //
            this.colMarke.DataPropertyName = "Marke";
            this.colMarke.HeaderText = "Marke";
            this.colMarke.Name = "colMarke";
            this.colMarke.ReadOnly = true;
            this.colMarke.Width = 105;
            //
            // colModell
            //
            this.colModell.DataPropertyName = "Modell";
            this.colModell.HeaderText = "Modell";
            this.colModell.Name = "colModell";
            this.colModell.ReadOnly = true;
            this.colModell.Width = 115;
            //
            // colBaujahr
            //
            this.colBaujahr.DataPropertyName = "Baujahr";
            this.colBaujahr.HeaderText = "Baujahr";
            this.colBaujahr.Name = "colBaujahr";
            this.colBaujahr.ReadOnly = true;
            this.colBaujahr.Width = 80;
            //
            // colPS
            //
            this.colPS.DataPropertyName = "MotorleistungPS";
            this.colPS.HeaderText = "PS";
            this.colPS.Name = "colPS";
            this.colPS.ReadOnly = true;
            this.colPS.Width = 60;
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
            this.colKm.Width = 95;
            //
            // colKraftstoff
            //
            this.colKraftstoff.DataPropertyName = "Kraftstoff";
            this.colKraftstoff.HeaderText = "Kraftstoff";
            this.colKraftstoff.Name = "colKraftstoff";
            this.colKraftstoff.ReadOnly = true;
            this.colKraftstoff.Width = 95;
            //
            // colGetriebe
            //
            this.colGetriebe.DataPropertyName = "Getriebe";
            this.colGetriebe.HeaderText = "Getriebe";
            this.colGetriebe.Name = "colGetriebe";
            this.colGetriebe.ReadOnly = true;
            this.colGetriebe.Width = 120;
            //
            // colZustand
            //
            this.colZustand.DataPropertyName = "Zustand";
            this.colZustand.HeaderText = "Zustand";
            this.colZustand.Name = "colZustand";
            this.colZustand.ReadOnly = true;
            this.colZustand.Width = 95;
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
            this.colPreis.Width = 115;
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
            this.pnlUnten.Location = new System.Drawing.Point(0, 608);
            this.pnlUnten.Name = "pnlUnten";
            this.pnlUnten.Size = new System.Drawing.Size(1180, 72);
            this.pnlUnten.TabIndex = 4;
            //
            // btnHinzufuegen
            //
            this.btnHinzufuegen.Location = new System.Drawing.Point(24, 16);
            this.btnHinzufuegen.Name = "btnHinzufuegen";
            this.btnHinzufuegen.Size = new System.Drawing.Size(140, 40);
            this.btnHinzufuegen.TabIndex = 0;
            this.btnHinzufuegen.Text = "+  Hinzufügen";
            this.btnHinzufuegen.UseVisualStyleBackColor = true;
            this.btnHinzufuegen.Click += new System.EventHandler(this.btnHinzufuegen_Click);
            //
            // btnBearbeiten
            //
            this.btnBearbeiten.Location = new System.Drawing.Point(174, 16);
            this.btnBearbeiten.Name = "btnBearbeiten";
            this.btnBearbeiten.Size = new System.Drawing.Size(130, 40);
            this.btnBearbeiten.TabIndex = 1;
            this.btnBearbeiten.Text = "Bearbeiten";
            this.btnBearbeiten.UseVisualStyleBackColor = true;
            this.btnBearbeiten.Click += new System.EventHandler(this.btnBearbeiten_Click);
            //
            // btnLoeschen
            //
            this.btnLoeschen.Location = new System.Drawing.Point(314, 16);
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.Size = new System.Drawing.Size(130, 40);
            this.btnLoeschen.TabIndex = 2;
            this.btnLoeschen.Text = "Löschen";
            this.btnLoeschen.UseVisualStyleBackColor = true;
            this.btnLoeschen.Click += new System.EventHandler(this.btnLoeschen_Click);
            //
            // btnVerkaufen
            //
            this.btnVerkaufen.Location = new System.Drawing.Point(454, 16);
            this.btnVerkaufen.Name = "btnVerkaufen";
            this.btnVerkaufen.Size = new System.Drawing.Size(130, 40);
            this.btnVerkaufen.TabIndex = 3;
            this.btnVerkaufen.Text = "Verkaufen";
            this.btnVerkaufen.UseVisualStyleBackColor = true;
            this.btnVerkaufen.Click += new System.EventHandler(this.btnVerkaufen_Click);
            //
            // btnFinanzierung
            //
            this.btnFinanzierung.Location = new System.Drawing.Point(594, 16);
            this.btnFinanzierung.Name = "btnFinanzierung";
            this.btnFinanzierung.Size = new System.Drawing.Size(130, 40);
            this.btnFinanzierung.TabIndex = 4;
            this.btnFinanzierung.Text = "Finanzierung";
            this.btnFinanzierung.UseVisualStyleBackColor = true;
            this.btnFinanzierung.Click += new System.EventHandler(this.btnFinanzierung_Click);
            //
            // btnSpeichern
            //
            this.btnSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeichern.Location = new System.Drawing.Point(1016, 16);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(140, 40);
            this.btnSpeichern.TabIndex = 5;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 680);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(20, 0, 20, 4);
            this.statusStrip.Size = new System.Drawing.Size(1180, 26);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 5;
            //
            // lblInfo
            //
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 706);
            this.Controls.Add(this.pnlTabelle);
            this.Controls.Add(this.pnlUnten);
            this.Controls.Add(this.pnlOben);
            this.Controls.Add(this.pnlKarten);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KaufAuto OP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKarten.ResumeLayout(false);
            this.pnlOben.ResumeLayout(false);
            this.pnlOben.PerformLayout();
            this.pnlTabelle.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.FlowLayoutPanel pnlKarten;
        private KaufAuto.GUI.KennzahlKarte kpiVerfuegbar;
        private KaufAuto.GUI.KennzahlKarte kpiBestand;
        private KaufAuto.GUI.KennzahlKarte kpiVerkauft;
        private KaufAuto.GUI.KennzahlKarte kpiUmsatz;
        private System.Windows.Forms.Panel pnlOben;
        private System.Windows.Forms.Label lblSuche;
        private System.Windows.Forms.TextBox txtSuche;
        private System.Windows.Forms.Label lblKraftstoff;
        private System.Windows.Forms.ComboBox cmbKraftstoff;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Panel pnlTabelle;
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
        private KaufAuto.GUI.ModernButton btnHinzufuegen;
        private KaufAuto.GUI.ModernButton btnBearbeiten;
        private KaufAuto.GUI.ModernButton btnLoeschen;
        private KaufAuto.GUI.ModernButton btnVerkaufen;
        private KaufAuto.GUI.ModernButton btnFinanzierung;
        private KaufAuto.GUI.ModernButton btnSpeichern;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
    }
}
