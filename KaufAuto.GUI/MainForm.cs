using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KaufAuto.Models;
using KaufAuto.Services;

namespace KaufAuto.GUI
{
    // Hauptfenster: Tabelle mit allen Autos und Buttons für die Aktionen
    public partial class MainForm : Form
    {
        private readonly AutoManager manager = new AutoManager();
        private readonly SpeicherService speicher = new SpeicherService();

        public MainForm()
        {
            InitializeComponent();
            cmbKraftstoff.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            DesignAnwenden();
        }

        // Farben und Stile aus der Klasse Design übernehmen
        private void DesignAnwenden()
        {
            BackColor = Design.Hintergrund;
            pnlOben.BackColor = Design.Flaeche;
            pnlUnten.BackColor = Design.Flaeche;
            statusStrip.BackColor = Design.Flaeche;
            statusStrip.SizingGrip = false;

            // Untertitel direkt neben den Titel setzen
            lblUntertitel.Left = lblTitel.Right + 10;
            lblUntertitel.Top = lblTitel.Bottom - lblUntertitel.Height - 3;

            Design.Tabelle(dgvAutos);
            dgvAutos.CellFormatting += dgvAutos_CellFormatting;

            Design.PrimaerButton(btnHinzufuegen);
            Design.NormalerButton(btnBearbeiten);
            Design.GefahrButton(btnLoeschen);
            Design.NormalerButton(btnVerkaufen);
            Design.NormalerButton(btnFinanzierung);
            Design.PrimaerButton(btnSpeichern);
        }

        // Status-Spalte farbig: Verfügbar = grün, Verkauft = grau
        private void dgvAutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAutos.Columns[e.ColumnIndex] != colStatus || e.Value == null)
                return;

            bool verkauft = e.Value.ToString() == "Verkauft";
            e.Value = verkauft ? "● Verkauft" : "● Verfügbar";
            e.CellStyle.ForeColor = verkauft ? Design.TextGedaempft : Design.Erfolg;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.Font = Design.SchriftFett;
            e.FormattingApplied = true;
        }

        // Beim Start: Autos aus autos.json laden
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                manager.SetAutos(speicher.Laden() ?? new List<Auto>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TabelleAktualisieren();
        }

        // Tabelle neu füllen (mit Suche und Filtern)
        private void TabelleAktualisieren(int? auswahlId = null)
        {
            IEnumerable<Auto> liste = manager.AlleAutos();

            string suche = txtSuche.Text.Trim().ToLower();
            if (suche != "")
            {
                liste = liste.Where(a =>
                    (a.Marke ?? "").ToLower().Contains(suche) ||
                    (a.Modell ?? "").ToLower().Contains(suche));
            }

            if (cmbKraftstoff.SelectedIndex > 0)
            {
                string kraftstoff = cmbKraftstoff.Text;
                liste = liste.Where(a => a.Kraftstoff == kraftstoff);
            }

            if (cmbStatus.SelectedIndex == 1)
            {
                liste = liste.Where(a => !a.Verkauft);
            }
            else if (cmbStatus.SelectedIndex == 2)
            {
                liste = liste.Where(a => a.Verkauft);
            }

            List<Auto> angezeigt = liste.ToList();
            dgvAutos.DataSource = null;
            dgvAutos.DataSource = angezeigt;

            // vorher ausgewähltes Auto wieder markieren
            if (auswahlId != null)
            {
                foreach (DataGridViewRow zeile in dgvAutos.Rows)
                {
                    if (((Auto)zeile.DataBoundItem).Id == auswahlId)
                    {
                        zeile.Selected = true;
                        dgvAutos.CurrentCell = zeile.Cells[0];
                        break;
                    }
                }
            }

            // Statusleiste unten
            var v = manager.ErstelleVerkaufsAuswertung();
            lblInfo.Text = $"Angezeigt: {angezeigt.Count}   |   Verfügbar: {v.verfuegbar} ({v.bestandswert:N2} €)" +
                           $"   |   Verkauft: {v.verkauft} (Umsatz {v.umsatz:N2} €)";

            // Sternchen im Titel = ungespeicherte Änderungen
            Text = "KaufAuto OP – Autoverwaltung" + (manager.HatUngespeicherteAenderungen ? " *" : "");
        }

        // verkaufte Autos grau anzeigen
        private void dgvAutos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow zeile in dgvAutos.Rows)
            {
                if (zeile.DataBoundItem is Auto auto && auto.Verkauft)
                {
                    zeile.DefaultCellStyle.ForeColor = Design.TextGedaempft;
                    zeile.DefaultCellStyle.SelectionForeColor = Design.TextGedaempft;
                }
            }
        }

        // aktuell ausgewähltes Auto (oder null mit Hinweis)
        private Auto AusgewaehltesAuto()
        {
            if (dgvAutos.CurrentRow?.DataBoundItem is Auto auto)
                return auto;

            MessageBox.Show("Bitte zuerst ein Auto in der Tabelle auswählen.", "Hinweis",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            TabelleAktualisieren();
        }

        private void btnHinzufuegen_Click(object sender, EventArgs e)
        {
            using (var form = new AutoForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Hinzufuegen(form.ErgebnisAuto);
                    TabelleAktualisieren(form.ErgebnisAuto.Id);
                }
            }
        }

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            Auto auto = AusgewaehltesAuto();
            if (auto == null)
                return;

            using (var form = new AutoForm(auto))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    manager.MarkiereAlsGeaendert();
                    TabelleAktualisieren(auto.Id);
                }
            }
        }

        // Doppelklick auf eine Zeile = Bearbeiten
        private void dgvAutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnBearbeiten_Click(sender, e);
        }

        private void btnLoeschen_Click(object sender, EventArgs e)
        {
            Auto auto = AusgewaehltesAuto();
            if (auto == null)
                return;

            var antwort = MessageBox.Show(
                $"{auto.Marke} {auto.Modell} (ID {auto.Id}) wirklich löschen?",
                "Löschen bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (antwort == DialogResult.Yes)
            {
                manager.Entfernen(auto.Id);
                TabelleAktualisieren();
            }
        }

        private void btnVerkaufen_Click(object sender, EventArgs e)
        {
            Auto auto = AusgewaehltesAuto();
            if (auto == null)
                return;

            if (auto.Verkauft)
            {
                MessageBox.Show($"Dieses Auto wurde bereits am {auto.Verkaufsdatum:dd.MM.yyyy} an {auto.Kaeufer} verkauft.",
                    "Bereits verkauft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new VerkaufenForm(auto))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Verkaufen(auto.Id, form.Kaeufer, form.Verkaufspreis);
                    TabelleAktualisieren(auto.Id);
                }
            }
        }

        private void btnFinanzierung_Click(object sender, EventArgs e)
        {
            Auto auto = AusgewaehltesAuto();
            if (auto == null)
                return;

            if (auto.Verkauft)
            {
                MessageBox.Show("Dieses Auto ist bereits verkauft.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new FinanzierungForm(auto))
            {
                form.ShowDialog(this);
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (Speichern())
            {
                MessageBox.Show("Daten wurden gespeichert.", "Gespeichert",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Speichern()
        {
            try
            {
                speicher.Speichern(manager.AlleAutos());
                manager.MarkiereAlsGespeichert();
                TabelleAktualisieren(AktuelleId());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern: {ex.Message}", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int? AktuelleId()
        {
            return (dgvAutos.CurrentRow?.DataBoundItem as Auto)?.Id;
        }

        // Beim Schließen: nach ungespeicherten Änderungen fragen
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!manager.HatUngespeicherteAenderungen)
                return;

            var antwort = MessageBox.Show(
                "Es gibt ungespeicherte Änderungen. Vor dem Beenden speichern?",
                "KaufAuto OP", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (antwort == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (antwort == DialogResult.Yes && !Speichern())
            {
                e.Cancel = true;
            }
        }
    }
}
