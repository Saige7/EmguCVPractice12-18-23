
namespace SpotTheDifference
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
            this.originalImage = new Emgu.CV.UI.ImageBox();
            this.finalImage = new Emgu.CV.UI.ImageBox();
            this.SpotTheDifference = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contourBox = new Emgu.CV.UI.ImageBox();
            this.absDiffImage = new Emgu.CV.UI.ImageBox();
            this.thresholdImage = new Emgu.CV.UI.ImageBox();
            this.differencesImage = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absDiffImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.differencesImage)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.originalImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.originalImage.Location = new System.Drawing.Point(12, 12);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(250, 250);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImage.TabIndex = 2;
            this.originalImage.TabStop = false;
            this.originalImage.Click += new System.EventHandler(this.originalImage_Click);
            // 
            // finalImage
            // 
            this.finalImage.Location = new System.Drawing.Point(382, 12);
            this.finalImage.Name = "finalImage";
            this.finalImage.Size = new System.Drawing.Size(250, 250);
            this.finalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.finalImage.TabIndex = 2;
            this.finalImage.TabStop = false;
            // 
            // SpotTheDifference
            // 
            this.SpotTheDifference.Location = new System.Drawing.Point(282, 110);
            this.SpotTheDifference.Name = "SpotTheDifference";
            this.SpotTheDifference.Size = new System.Drawing.Size(75, 53);
            this.SpotTheDifference.TabIndex = 3;
            this.SpotTheDifference.Text = "spot the difference";
            this.SpotTheDifference.UseVisualStyleBackColor = true;
            this.SpotTheDifference.Click += new System.EventHandler(this.SpotTheDifference_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = " _";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = " _";
            // 
            // contourBox
            // 
            this.contourBox.Location = new System.Drawing.Point(26, 293);
            this.contourBox.Name = "contourBox";
            this.contourBox.Size = new System.Drawing.Size(100, 100);
            this.contourBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.contourBox.TabIndex = 2;
            this.contourBox.TabStop = false;
            // 
            // absDiffImage
            // 
            this.absDiffImage.Location = new System.Drawing.Point(195, 293);
            this.absDiffImage.Name = "absDiffImage";
            this.absDiffImage.Size = new System.Drawing.Size(100, 100);
            this.absDiffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.absDiffImage.TabIndex = 2;
            this.absDiffImage.TabStop = false;
            // 
            // thresholdImage
            // 
            this.thresholdImage.Location = new System.Drawing.Point(364, 293);
            this.thresholdImage.Name = "thresholdImage";
            this.thresholdImage.Size = new System.Drawing.Size(100, 100);
            this.thresholdImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thresholdImage.TabIndex = 2;
            this.thresholdImage.TabStop = false;
            // 
            // differencesImage
            // 
            this.differencesImage.Location = new System.Drawing.Point(532, 293);
            this.differencesImage.Name = "differencesImage";
            this.differencesImage.Size = new System.Drawing.Size(100, 100);
            this.differencesImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.differencesImage.TabIndex = 2;
            this.differencesImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "contours to split image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "absDiff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "threshold";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(547, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "gray + blur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(651, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "image 2 dimensions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(651, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "image 1 dimensions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.differencesImage);
            this.Controls.Add(this.thresholdImage);
            this.Controls.Add(this.absDiffImage);
            this.Controls.Add(this.contourBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpotTheDifference);
            this.Controls.Add(this.finalImage);
            this.Controls.Add(this.originalImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absDiffImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.differencesImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox originalImage;
        private Emgu.CV.UI.ImageBox finalImage;
        private System.Windows.Forms.Button SpotTheDifference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox contourBox;
        private Emgu.CV.UI.ImageBox absDiffImage;
        private Emgu.CV.UI.ImageBox thresholdImage;
        private Emgu.CV.UI.ImageBox differencesImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

