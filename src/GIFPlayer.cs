using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MagmaMc.BetterForms
{
    public class GIFPlayer: PictureBox
    {
        private bool isStart = false;
        private BackgroundWorker backgroundWorker;

        public GIFPlayer()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += Loading;
        }

        private void Loading(object sender, DoWorkEventArgs e)
        {
            while (isStart)
            {
                Refresh();
            }
        }

        [Description("Load Image .gif in the object")]
        [Category("Appearance")]
        [DisplayName("GIF")]
        public new Image Image
        {
            get => base.Image;
            set => base.Image = value;
        }

        public void Start()
        {
            isStart = true;
            Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        public void Stop()
        {
            isStart = false;
            Visible = false;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GIFPlayer
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "GIFPlayer";
            this.Size = new System.Drawing.Size(150, 150);
            this.SizeMode = SizeMode;
            this.TabIndex = 0;
            this.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

    }

}
