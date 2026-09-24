using System.Drawing;
using System.Windows.Forms;

namespace KaufAuto.GUI
{
    // Zentrale Farben und Stile – hier ändern, dann ändert sich die ganze App
    internal static class Design
    {
        // Farbpalette
        public static readonly Color Primaer = ColorTranslator.FromHtml("#2563EB");       // Blau
        public static readonly Color PrimaerHover = ColorTranslator.FromHtml("#1D4ED8");
        public static readonly Color PrimaerHell = ColorTranslator.FromHtml("#DBEAFE");
        public static readonly Color Erfolg = ColorTranslator.FromHtml("#16A34A");        // Grün
        public static readonly Color Gefahr = ColorTranslator.FromHtml("#DC2626");        // Rot
        public static readonly Color GefahrHell = ColorTranslator.FromHtml("#FEE2E2");
        public static readonly Color Kopfzeile = ColorTranslator.FromHtml("#1E293B");     // Dunkelblau
        public static readonly Color Hintergrund = ColorTranslator.FromHtml("#F1F5F9");
        public static readonly Color Flaeche = Color.White;
        public static readonly Color ZeileAbwechselnd = ColorTranslator.FromHtml("#F8FAFC");
        public static readonly Color Rahmen = ColorTranslator.FromHtml("#E2E8F0");
        public static readonly Color Text = ColorTranslator.FromHtml("#0F172A");
        public static readonly Color TextGedaempft = ColorTranslator.FromHtml("#94A3B8");
        public static readonly Color HoverHell = ColorTranslator.FromHtml("#F1F5F9");

        public static readonly Font Schrift = new Font("Segoe UI", 9F);
        public static readonly Font SchriftFett = new Font("Segoe UI Semibold", 9F);

        // Hauptaktion (blau, weiße Schrift)
        public static void PrimaerButton(Button button)
        {
            FlacherButton(button, Primaer, Color.White, Primaer, PrimaerHover);
        }

        // normale Aktion (weiß mit grauem Rahmen)
        public static void NormalerButton(Button button)
        {
            FlacherButton(button, Flaeche, Text, Rahmen, HoverHell);
        }

        // gefährliche Aktion wie Löschen (weiß mit roter Schrift)
        public static void GefahrButton(Button button)
        {
            FlacherButton(button, Flaeche, Gefahr, Gefahr, GefahrHell);
        }

        private static void FlacherButton(Button button, Color hintergrund, Color schrift, Color rahmen, Color hover)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = hintergrund;
            button.ForeColor = schrift;
            button.Font = SchriftFett;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.FlatAppearance.BorderColor = rahmen;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = hover;
        }

        // moderne Tabelle: nur waagerechte Linien, abwechselnde Zeilenfarben
        public static void Tabelle(DataGridView tabelle)
        {
            tabelle.BorderStyle = BorderStyle.None;
            tabelle.BackgroundColor = Flaeche;
            tabelle.GridColor = Rahmen;
            tabelle.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabelle.RowTemplate.Height = 34;

            // Kopfzeile
            tabelle.EnableHeadersVisualStyles = false;
            tabelle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabelle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabelle.ColumnHeadersHeight = 38;
            tabelle.ColumnHeadersDefaultCellStyle.BackColor = Hintergrund;
            tabelle.ColumnHeadersDefaultCellStyle.ForeColor = Text;
            tabelle.ColumnHeadersDefaultCellStyle.Font = SchriftFett;
            tabelle.ColumnHeadersDefaultCellStyle.SelectionBackColor = Hintergrund;
            tabelle.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            // Zeilen
            tabelle.DefaultCellStyle.BackColor = Flaeche;
            tabelle.DefaultCellStyle.ForeColor = Text;
            tabelle.DefaultCellStyle.SelectionBackColor = PrimaerHell;
            tabelle.DefaultCellStyle.SelectionForeColor = Text;
            tabelle.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            tabelle.AlternatingRowsDefaultCellStyle.BackColor = ZeileAbwechselnd;
        }

        // Dialogfenster: weißer Hintergrund, OK blau, Abbrechen normal
        public static void Dialog(Form form, Button ok, Button abbrechen)
        {
            form.BackColor = Flaeche;
            form.ForeColor = Text;
            if (ok != null)
                PrimaerButton(ok);
            if (abbrechen != null)
                NormalerButton(abbrechen);
        }
    }
}
