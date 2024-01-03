using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotTheDifference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void originalImage_Click(object sender, EventArgs e)
        {
            finalImage.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            originalImage.Image = CvInvoke.Imread(imageOpened.FileName);
        }

        private void SpotTheDifference_Click(object sender, EventArgs e)
        {
            Mat image = originalImage.Image as Mat;
            
            Mat contourImage = image.Clone();
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(grayImage, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);
            CvInvoke.DrawContours(contourImage, contours, -1, new MCvScalar(0, 0, 255), 5);
            contourBox.Image = contourImage;

            Rectangle image1Bounds = CvInvoke.BoundingRectangle(contours[0]);
            Rectangle image2Bounds = CvInvoke.BoundingRectangle(contours[1]);

            Mat image1 = new Mat(image, image1Bounds);
            Mat image2 = new Mat(image, image2Bounds);

            CvInvoke.Resize(image2, image2, image1.Size);
            label1.Text = $"{image1.Width} , {image1.Height}";
            label2.Text = $"{image2.Width} , {image2.Height}";

            Mat image1Blur = new Mat();
            Mat image2Blur = new Mat();
            CvInvoke.Blur(image1, image1Blur, new Size(7, 7), new Point(-1, -1), BorderType.Constant);
            CvInvoke.Blur(image2, image2Blur, new Size(7, 7), new Point(-1, -1), BorderType.Constant);

            Mat absDiff = new Mat();
            CvInvoke.AbsDiff(image1Blur, image2Blur, absDiff);
            absDiffImage.Image = absDiff;

            Mat threshold = new Mat();
            CvInvoke.Threshold(absDiff, threshold, 66, 255, ThresholdType.Binary);
            thresholdImage.Image = threshold;
            //threshold slider to determine what # ^ to use

            Mat otherGrayImage = new Mat();
            CvInvoke.CvtColor(threshold, otherGrayImage, ColorConversion.Bgr2Gray);
            CvInvoke.Blur(otherGrayImage, otherGrayImage, new Size(10, 10), new Point(-1, -1), BorderType.Constant);
            VectorOfVectorOfPoint differences = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(otherGrayImage, differences, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);
            CvInvoke.DrawContours(otherGrayImage, differences, -1, new MCvScalar(0, 0, 255, 5));
            differencesImage.Image = otherGrayImage;

            for (int i = 0; i < differences.Size; i++)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(differences[i]);
                rect.Width += 10;
                rect.Height += 10;
                CvInvoke.Rectangle(image, rect, new MCvScalar(0, 0, 0), 2);
                CvInvoke.Rectangle(image, new Rectangle(rect.Location.X, rect.Location.Y + 248, rect.Width, rect.Height), new MCvScalar(0, 0, 0), 2);
            }            

            finalImage.Image = image;
        }
    }
}
