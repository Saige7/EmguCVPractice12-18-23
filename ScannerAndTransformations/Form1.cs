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

namespace ScannerAndTransformations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCapture capture;
        private Mat photo;

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);

            Application.Idle += GrabFromIdle;
        }
        private void GrabFromIdle(object sender, EventArgs e)
        {
            if (!capture.Grab())
            {
                return;
            }

            using Mat originalFrame = capture.QueryFrame();
            camera.Image?.Dispose();

            Mat smallCurrentFrame = new Mat();
            CvInvoke.Resize(originalFrame, smallCurrentFrame, new Size(originalFrame.Width / 2, originalFrame.Height / 2));
            CvInvoke.Flip(smallCurrentFrame, smallCurrentFrame, FlipType.Horizontal);

            camera.Image = smallCurrentFrame;
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            Application.Idle -= GrabFromIdle;

            photo = camera.Image as Mat;
        }

        private void AffineTransformation_Click(object sender, EventArgs e)
        {
            Mat affineTransformation = new Mat();
            Mat blur = new Mat();

            CvInvoke.Blur(photo, blur, new Size(16, 16), new Point(-1, -1), BorderType.Constant);

            Mat hsv = new Mat();
            CvInvoke.CvtColor(blur, hsv, ColorConversion.Bgr2Hsv);
            Mat paper = new Mat();
            CvInvoke.InRange(hsv, (ScalarArray)new MCvScalar(0, 0, 60), (ScalarArray)new MCvScalar(180, 17, 255), paper);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            Mat contourImage = photo.Clone();
            CvInvoke.FindContours(paper, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);
            CvInvoke.DrawContours(contourImage, contours, -1, new MCvScalar(0, 0, 255), 3);
            
            int correctContour = 0;
            double area = CvInvoke.ContourArea(contours[0], false);
            for (int i = 1; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > area)
                {
                    area = CvInvoke.ContourArea(contours[i]);
                    correctContour = i;
                }
            }
            RotatedRect rect = CvInvoke.MinAreaRect(contours[correctContour]);
            var verticies = rect.GetVertices().Select(pt => new Point((int)pt.X, (int)pt.Y)).ToArray();
            //CvInvoke.Line(prompt, verticies[0], verticies[1], new MCvScalar(0, 255, 0), 2);
            //CvInvoke.Line(prompt, verticies[1], verticies[2], new MCvScalar(0, 255, 0), 2);
            //CvInvoke.Line(prompt, verticies[2], verticies[3], new MCvScalar(0, 255, 0), 2);
            //CvInvoke.Line(prompt, verticies[3], verticies[0], new MCvScalar(0, 255, 0), 2);

            PointF[] sourcePoints = { verticies[2], verticies[3], verticies[1] };
            PointF[] destinationPoints = { new Point(0, 0), new Point(0, imageBox2.Height), new Point(imageBox2.Width, 0) };
            Mat mapMatrix = CvInvoke.GetAffineTransform(sourcePoints, destinationPoints);

            CvInvoke.WarpAffine(photo, affineTransformation, mapMatrix, photo.Size, Inter.Linear, Warp.Default, BorderType.Constant, new MCvScalar(0, 0, 0));
            CvInvoke.Flip(affineTransformation, affineTransformation, FlipType.Horizontal);

            imageBox2.Image = affineTransformation;
            imageBox3.Image = contourImage; 
            imageBox1.Image = paper;
        }

        private void warpPerspectiveButton_Click(object sender, EventArgs e)
        {
            Mat warpPerspective = new Mat();

            Mat blur = new Mat();
            CvInvoke.Blur(photo, blur, new Size(13, 13), new Point(-1, -1), BorderType.Constant);

            Mat hsv = new Mat();
            CvInvoke.CvtColor(blur, hsv, ColorConversion.Bgr2Hsv);
            Mat paper = new Mat();
            CvInvoke.InRange(hsv, (ScalarArray)new MCvScalar(0, 0, 60), (ScalarArray)new MCvScalar(180, 17, 255), paper);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            Mat contourImage = photo.Clone();
            CvInvoke.FindContours(paper, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);

            int correctContour = 0;
            double area = CvInvoke.ContourArea(contours[0], false);
            for (int i = 1; i < contours.Size; i++)
            {
                if (area < CvInvoke.ContourArea(contours[i], false))
                {
                    area = CvInvoke.ContourArea(contours[i], false);
                    correctContour = i;
                }
            }

            VectorOfPoint output = new();
            CvInvoke.ApproxPolyDP(contours[correctContour], output, 10, true);
            CvInvoke.DrawContours(contourImage, contours, -1, new MCvScalar(0, 0, 255), 3);

            PointF[] sourcePoints = {output[3], output[2], output[1], output[0]};
            PointF[] destinationPoints = { new Point(0, 0), new Point(imageBox2.Width, 0),
                new Point(imageBox2.Width, imageBox2.Height), new Point(0, imageBox2.Height) };
            Mat mapMatrix = CvInvoke.GetPerspectiveTransform(sourcePoints, destinationPoints);

            CvInvoke.WarpPerspective(photo, warpPerspective, mapMatrix, photo.Size, Inter.Linear, Warp.Default, BorderType.Constant, new MCvScalar(0, 0, 0));

            imageBox2.Image = warpPerspective;
            imageBox3.Image = contourImage;
            imageBox1.Image = paper;
        }
    }
}
