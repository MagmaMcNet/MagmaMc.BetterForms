using MagmaMc.BetterForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagmaMc.BetterForms
{
    public class InputData
    {
        public string Value { get; set; }
        public bool Canceled { get; set; } = false;
    }

    public static class InputBox
    {
        public static InputData Show(string Text, string Title, byte min = 0, bool DarkMode = true)
        {
            _InputBox box = new _InputBox(DarkMode, Text, Title, min);
            box.ShowDialog();
            return box.outdata;
        }
    }


    internal partial class _InputBox: Form
    {
        public string _m_MainText = "";
        public string _m_TitleText = "";
        byte mintext = 5;
        public InputData outdata = new InputData() { Canceled = true };
        private FormRounder Rounder { get; set; }
        public _InputBox(bool Dark, string text, string title, byte min = 0)
        {
            _m_MainText = text;
            _m_TitleText = title;
            mintext = min;
            if (Dark)
            {
                Colors.Add("Titlebar", Color.FromArgb(30, 30, 30));
                Colors.Add("Back", Color.FromArgb(34, 34, 34));
                Colors.Add("Text", Color.FromArgb(255, 255, 255));
                Colors.Add("ButtonBack", Color.FromArgb(24, 24, 24));
            }
            else
            {
                Colors.Add("Titlebar", Color.FromArgb(250, 250, 250));
                Colors.Add("Back", Color.FromArgb(240, 240, 240));
                Colors.Add("Text", Color.FromArgb(5, 5, 5));
                Colors.Add("ButtonBack", Color.FromArgb(222, 222, 220));

            }

            InitializeComponent();
            Rounder = new FormRounder(this, 10, BackColor);
        }

        private void Form_Paint(object sender, PaintEventArgs e) =>
            Rounder.Round(e);
        private void Draggable_Object(object sender, MouseEventArgs e) =>
            Rounder.Object_Draggable();

        private void Exit_Click(object sender, EventArgs e)
        {
            outdata = new InputData() { Canceled = true };
            Dispose();
        }
        private void OkClick(object sender, EventArgs e)
        {
            try
            {
                if (mintext > textBox1.Text.Length)
                {
                    throw new Exception("Input Is Smaller Than Min Value: " + mintext.ToString());
                }
                outdata = new InputData() { Canceled = false, Value = this.textBox1.Text };
                Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
