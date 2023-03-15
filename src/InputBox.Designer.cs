using System.Collections.Generic;
using System.Drawing;

namespace MagmaMc.BetterForms
{
    internal partial class _InputBox
    {
        public Dictionary<string, Color> Colors = new Dictionary<string, Color>();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.Titlebar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.Label();
            this.Titlebar_Text = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.betterButtons1 = new MagmaMc.BetterForms.BetterButton();
            this.MainText = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Titlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(100, 23);
            this.title.TabIndex = 0;
            // 
            // Titlebar
            // 
            this.Titlebar.BackColor = Colors["Titlebar"];
            this.Titlebar.Controls.Add(this.pictureBox1);
            this.Titlebar.Controls.Add(this.Exit);
            this.Titlebar.Controls.Add(this.Titlebar_Text);
            this.Titlebar.Location = new System.Drawing.Point(-1, -1);
            this.Titlebar.Name = "Titlebar";
            this.Titlebar.Size = new System.Drawing.Size(320, 31);
            this.Titlebar.TabIndex = 0;
            this.Titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Draggable_Object);
            this.Titlebar.ForeColor = Colors["Text"]; 
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MagmaMc.BetterForms.Properties.Resources.App;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Exit.ForeColor = System.Drawing.SystemColors.Control;
            this.Exit.Location = new System.Drawing.Point(279, 1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(40, 26);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "x";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.ForeColor = Colors["Text"];
            // 
            // Titlebar_Text
            // 
            this.Titlebar_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Titlebar_Text.ForeColor = System.Drawing.Color.White;
            this.Titlebar_Text.Location = new System.Drawing.Point(40, 0);
            this.Titlebar_Text.Name = "Titlebar_Text";
            this.Titlebar_Text.Size = new System.Drawing.Size(209, 28);
            this.Titlebar_Text.TabIndex = 0;
            this.Titlebar_Text.Text = "Titlebar_Text";
            this.Titlebar_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Titlebar_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Draggable_Object);
            this.Titlebar_Text.ForeColor = Colors["Text"];
            this.Titlebar_Text.Text = _m_TitleText;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 93);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.ForeColor = Colors["Text"];
            this.textBox1.BackColor = Colors["ButtonBack"];
            // 
            // betterButtons1
            // 
            this.betterButtons1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.betterButtons1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.betterButtons1.BorderColor = System.Drawing.Color.Orange;
            this.betterButtons1.BorderRadius = 10;
            this.betterButtons1.BorderSize = 5;
            this.betterButtons1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.betterButtons1.ForeColor = System.Drawing.Color.White;
            this.betterButtons1.Location = new System.Drawing.Point(0, 0);
            this.betterButtons1.Name = "betterButtons1";
            this.betterButtons1.Size = new System.Drawing.Size(150, 40);
            this.betterButtons1.TabIndex = 0;
            this.betterButtons1.TextColor = System.Drawing.Color.White;
            this.betterButtons1.UseVisualStyleBackColor = false;
            this.betterButtons1.Value = null;
            this.betterButtons1.ForeColor = Colors["Text"];
            // 
            // MainText
            // 
            this.MainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainText.ForeColor = System.Drawing.Color.White;
            this.MainText.Location = new System.Drawing.Point(12, 42);
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(295, 48);
            this.MainText.TabIndex = 2;
            this.MainText.Text = "MainText";
            this.MainText.ForeColor = Colors["Text"];
            this.MainText.Text = _m_MainText;
            // 
            // OkButton
            // 
            this.OkButton.Click += new System.EventHandler(this.OkClick);
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.ForeColor = System.Drawing.Color.White;
            this.OkButton.Location = new System.Drawing.Point(14, 136);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(86, 24);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.ForeColor = Colors["Text"];
            this.OkButton.BackColor = Colors["ButtonBack"];
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(221, 136);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 24);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.ForeColor = Colors["Text"];
            this.Cancel.BackColor = Colors["ButtonBack"];
            this.Cancel.Click += new System.EventHandler(this.Exit_Click);
            // 
            // InputBox
            // 
            this.BackColor = Colors["Back"];
            this.ClientSize = new System.Drawing.Size(319, 168);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MainText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.Titlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MagmaMc.BetterForms.BetterButton betterButtons1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel Titlebar;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label Titlebar_Text;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label MainText;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}