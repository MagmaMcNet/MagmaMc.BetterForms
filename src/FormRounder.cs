using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagmaMc.BetterForms
{
    public class FormRounder
    {
        private Form ExternalForm { get; set; }

        private int borderRadius { get; set; } = 15;
        private int borderSize { get; set; } = 2;
        private Color borderColor { get; set; } = Color.FromArgb(50, 52, 54);


        public FormRounder(Form Parm_Form)
        {
            ExternalForm = Parm_Form;
            ExternalForm.FormBorderStyle = FormBorderStyle.None;
        }
        public FormRounder(Form Parm_Form, int RoundAmount)
        {
            ExternalForm = Parm_Form;
            borderRadius = RoundAmount;
            ExternalForm.FormBorderStyle = FormBorderStyle.None;
        }
        public FormRounder(Form Parm_Form, int RoundAmount, Color Color)
        {
            ExternalForm = Parm_Form;
            borderRadius = RoundAmount;
            borderColor = Color;
            ExternalForm.FormBorderStyle = FormBorderStyle.None;
        }

        public void Round(PaintEventArgs PaintEvent)
        {
            //-> SMOOTH OUTER BORDER
            PaintEvent.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(ExternalForm, borderRadius, PaintEvent.Graphics, borderColor, borderSize);

        }
        public void Object_Draggable()
        {
            ReleaseCapture();
            SendMessage(ExternalForm.Handle, 0x112, 0xf012, 0);
        }


        // Private

        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
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
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (ExternalForm.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.HighQuality;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    }
}
