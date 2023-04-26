using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MagmaMc.BetterForms
{

    public class RoundPictureBox: PictureBox
    {
        private Color borderColor = Color.Black;
        private int borderWidth = 2;

        public RoundPictureBox()
        {
            TypeDescriptor.AddAttributes(typeof(RoundPictureBox), new CategoryAttribute("Appearance"));
        }


        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (Image == null)
            {
                base.OnPaint(pe);
                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(0, 0, Width, Height);
                    Region = new Region(gp);
                    pe.Graphics.SetClip(gp);
                }
                return;
            }
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, Width, Height);
                Region = new Region(gp);
                pe.Graphics.SetClip(gp);
            }

            base.OnPaint(pe);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Image == null) { base.OnPaintBackground(e); }
        }
    }
}
