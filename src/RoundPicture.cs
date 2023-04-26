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
        private int roundAmount = 100; // default value is 100%

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
            set { if (value > roundAmount) throw new ArgumentOutOfRangeException(nameof(BorderWidth), "Value must "); borderWidth = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int RoundAmount
        {
            get { return roundAmount; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(RoundAmount), "Value must be between 0 and 100.");
                roundAmount = value;
                Invalidate();
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Rectangle ImageRectangleFromSizeMode(PictureBoxSizeMode mode)
        {
            Rectangle result = Rectangle.Empty;
            if (Image != null)
            {
                switch (mode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        result.Size = Image.Size;
                        break;
                    case PictureBoxSizeMode.CenterImage:
                        result.X += (result.Width - Image.Width) / 2;
                        result.Y += (result.Height - Image.Height) / 2;
                        result.Size = Image.Size;
                        break;
                    case PictureBoxSizeMode.Zoom:
                        {
                            Size size = Image.Size;
                            float num = Math.Min((float)base.ClientRectangle.Width / (float)size.Width, (float)base.ClientRectangle.Height / (float)size.Height);
                            result.Width = (int)((float)size.Width * num);
                            result.Height = (int)((float)size.Height * num);
                            result.X = (base.ClientRectangle.Width - result.Width) / 2;
                            result.Y = (base.ClientRectangle.Height - result.Height) / 2;
                            break;
                        }
                }
            }

            return result;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (roundAmount < 2)
                return;
            // Set up variables for drawing the border and picture
            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderWidth, -BorderWidth);
            int smoothSize = 2;
            if (BorderWidth > 0)
                smoothSize = BorderWidth;

            using (var pathSurface = GetFigurePath(rectSurface, RoundAmount))
            using (var pathBorder = GetFigurePath(rectBorder, RoundAmount - BorderWidth))
            using (var penSurface = new Pen(Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(BorderColor, BorderWidth))
            {
                // Set the smoothing mode and region for the picture
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Region = new Region(pathSurface);

                // Draw the surface border for HD result
                pe.Graphics.DrawPath(penSurface, pathSurface);

                // Draw the picture
                if (Image != null)
                {
                    pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    //pe.Graphics.DrawImage(Image, rectBorder);
                    pe.Graphics.DrawImage(Image, ImageRectangleFromSizeMode(SizeMode));
                }

                // Draw the border
                if (BorderWidth >= 1)
                    pe.Graphics.DrawPath(penBorder, pathBorder);
            }
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Image == null)
                base.OnPaintBackground(e);
        }
    }

}
