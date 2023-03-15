using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MagmaMc.BetterForms
{

    public class GIFPlayer : UserControl
    {
        public bool IsStart { get; private set; } = false;

        private readonly IContainer components = null;

        private PictureBox PB;

        [Description("Load Image .gif in the object")]
        [Category("Appearance")]
        public Image GIF
        {
            get
            {
                return PB.Image;
            }
            set
            {
                PB.Image = value;
            }
        }

        public GIFPlayer()
        {
            InitializeComponent();
        }

        public void Start()
        {
            IsStart = true;
            Visible = true;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += Loading;
            backgroundWorker.RunWorkerAsync();
        }

        public void Stop()
        {
            IsStart = false;
            Visible = false;
        }

        private void Loading(object sender, DoWorkEventArgs e)
        {
            while (IsStart)
            {
                Refresh();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            PB = new PictureBox();
            ((ISupportInitialize)PB).BeginInit();
            SuspendLayout();
            PB.BackColor = Color.Transparent;
            PB.Dock = DockStyle.Fill;
            PB.Location = new Point(0, 0);
            PB.Name = "PB";
            PB.Size = new Size(128, 128);
            PB.SizeMode = PictureBoxSizeMode.StretchImage;
            PB.TabIndex = 13;
            PB.TabStop = false;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PB);
            Name = "GIFImage";
            Size = new Size(128, 128);
            ((ISupportInitialize)PB).EndInit();
            ResumeLayout(false);
        }
    }
}