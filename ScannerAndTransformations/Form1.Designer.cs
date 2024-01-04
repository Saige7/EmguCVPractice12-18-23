
namespace ScannerAndTransformations
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
            this.camera = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.photoButton = new System.Windows.Forms.Button();
            this.AffineTransformation = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.camera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // camera
            // 
            this.camera.Location = new System.Drawing.Point(12, 33);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(285, 274);
            this.camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.camera.TabIndex = 2;
            this.camera.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(454, 33);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(285, 274);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // photoButton
            // 
            this.photoButton.Location = new System.Drawing.Point(245, 313);
            this.photoButton.Name = "photoButton";
            this.photoButton.Size = new System.Drawing.Size(52, 30);
            this.photoButton.TabIndex = 3;
            this.photoButton.Text = "photo";
            this.photoButton.UseVisualStyleBackColor = true;
            this.photoButton.Click += new System.EventHandler(this.photoButton_Click);
            // 
            // AffineTransformation
            // 
            this.AffineTransformation.Location = new System.Drawing.Point(319, 163);
            this.AffineTransformation.Name = "AffineTransformation";
            this.AffineTransformation.Size = new System.Drawing.Size(116, 38);
            this.AffineTransformation.TabIndex = 4;
            this.AffineTransformation.Text = "affine transformation";
            this.AffineTransformation.UseVisualStyleBackColor = true;
            this.AffineTransformation.Click += new System.EventHandler(this.AffineTransformation_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 353);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(188, 161);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(247, 353);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(188, 161);
            this.imageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox3.TabIndex = 5;
            this.imageBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(751, 526);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.AffineTransformation);
            this.Controls.Add(this.photoButton);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.camera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox camera;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button photoButton;
        private System.Windows.Forms.Button AffineTransformation;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox3;
    }
}

