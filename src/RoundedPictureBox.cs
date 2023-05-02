using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MagmaMc.BetterForms
{
    public class RoundedPictureBox: PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(gp);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            base.OnPaint(e);
        }
    }
}
