using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KaufAuto.GUI
{
    // Button mit abgerundeten Ecken und weichem Hover-Effekt
    public class ModernButton : Button
    {
        private bool mausDrueber;

        [Category("Design"), Description("Rundung der Ecken in Pixeln.")]
        public int Radius { get; set; } = 8;

        [Category("Design"), Description("Hintergrundfarbe, wenn die Maus darüber ist.")]
        public Color HoverFarbe { get; set; } = Color.Empty;

        [Category("Design"), Description("Farbe des Rahmens (Empty = kein Rahmen).")]
        public Color RahmenFarbe { get; set; } = Color.Empty;

        public ModernButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mausDrueber = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mausDrueber = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent?.BackColor ?? BackColor);

            Color hintergrund = mausDrueber && !HoverFarbe.IsEmpty ? HoverFarbe : BackColor;
            Color schrift = ForeColor;
            if (!Enabled)
            {
                hintergrund = ControlPaint.Dark(hintergrund, 0.1f);
                schrift = Color.Gray;
            }

            var rechteck = new RectangleF(0.5f, 0.5f, Width - 1.5f, Height - 1.5f);
            using (GraphicsPath pfad = Design.Abgerundet(rechteck, Radius))
            {
                using (var pinsel = new SolidBrush(hintergrund))
                    g.FillPath(pinsel, pfad);

                if (!RahmenFarbe.IsEmpty)
                {
                    using (var stift = new Pen(RahmenFarbe))
                        g.DrawPath(stift, pfad);
                }

                // Tastatur-Fokus: feiner goldener Rahmen
                if (Focused && ShowFocusCues)
                {
                    using (var stift = new Pen(Design.Gold, 1.5f))
                        g.DrawPath(stift, pfad);
                }
            }

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, schrift,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }
    }
}
