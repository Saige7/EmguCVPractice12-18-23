﻿namespace PingPongCV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playerScore = new System.Windows.Forms.Label();
            this.computerScore = new System.Windows.Forms.Label();
            this.camera = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(333, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(612, 396);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // playerScore
            // 
            this.playerScore.AutoSize = true;
            this.playerScore.Location = new System.Drawing.Point(846, 25);
            this.playerScore.Name = "playerScore";
            this.playerScore.Size = new System.Drawing.Size(19, 15);
            this.playerScore.TabIndex = 1;
            this.playerScore.Text = "00";
            // 
            // computerScore
            // 
            this.computerScore.AutoSize = true;
            this.computerScore.Location = new System.Drawing.Point(373, 25);
            this.computerScore.Name = "computerScore";
            this.computerScore.Size = new System.Drawing.Size(19, 15);
            this.computerScore.TabIndex = 1;
            this.computerScore.Text = "00";
            // 
            // camera
            // 
            this.camera.Location = new System.Drawing.Point(31, 53);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(204, 198);
            this.camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.camera.TabIndex = 2;
            this.camera.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(975, 528);
            this.Controls.Add(this.camera);
            this.Controls.Add(this.computerScore);
            this.Controls.Add(this.playerScore);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label playerScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label computerScore;
        private Emgu.CV.UI.ImageBox camera;
    }
}

