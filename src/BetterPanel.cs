using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace MagmaMc.BetterForms
{
    public class BetterPanel: Panel
    {
        private float _radius = 10.0f;
        private float _borderSize = 1.0f;
        private Color _borderColor = Color.Black;
        private Color _backgroundColor = Color.White;

        [Category("Appearance")]
        [DisplayName("Border Curve")]
        public float BorderCurve
        {
            get => _radius;
            set
            {
                _radius = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DisplayName("Border Size")]
        public float BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                Invalidate();
            }
        }


        [Category("Appearance")]
        [DisplayName("Border Color")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            using (GraphicsPath roundPath = GetRoundedPath(ClientRectangle, _radius))
            using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
            using (Pen penBorder = new Pen(_borderColor, _borderSize))
            using (Matrix transform = new Matrix())
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillPath(backgroundBrush, roundPath);
                Region = new Region(roundPath);
                if (_borderSize >= 1)
                {
                    RectangleF rect = new RectangleF(_borderSize / 2, _borderSize / 2, Width - _borderSize, Height - _borderSize);
                    float scaleX = 1.0F - (_borderSize / Width);
                    float scaleY = 1.0F - (_borderSize / Height);
                    transform.Scale(scaleX, scaleY);
                    transform.Translate(_borderSize / 2, _borderSize / 2);
                    e.Graphics.Transform = transform;
                    e.Graphics.DrawPath(penBorder, roundPath);
                }
            }
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
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
    }
}