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

namespace Platformer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCapture capture;
        private Rectangle player;
        private int speed;

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
            player = new Rectangle(50, 50, 15, 15);
            speed = 5;

            gameTimer.Enabled = true;
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

            Mat currentFrame = new Mat();
            CvInvoke.Resize(originalFrame, currentFrame, new Size(originalFrame.Width / 2, originalFrame.Height / 2));

            camera.Image = currentFrame;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (camera.Image == null)
            {
                return;
            }
            Mat currentFrame = camera.Image as Mat;

            using Mat frameHSV = new Mat();
            CvInvoke.CvtColor(currentFrame, frameHSV, ColorConversion.Bgr2Hsv);
            CvInvoke.Blur(frameHSV, frameHSV, new Size(14, 14), new Point(-1, -1), BorderType.Constant);

            using Mat paper = new Mat();
            CvInvoke.InRange(frameHSV, (ScalarArray)new MCvScalar(0, 0, 180), (ScalarArray)new MCvScalar(180, 50, 255), paper);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(paper, contours, hierarchy, RetrType.Ccomp, ChainApproxMethod.ChainApproxNone);
            using Mat contourImage = currentFrame.Clone();
            //CvInvoke.DrawContours(contourImage, contours, -1, new MCvScalar(255, 0, 200), 3);      

            int biggestContour = 0;
            double area = CvInvoke.ContourArea(contours[0], false);
            for (int i = 1; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > area)
                {
                    area = CvInvoke.ContourArea(contours[i], false);
                    biggestContour = i;
                }
            }
            
            VectorOfPoint output = new();
            CvInvoke.ApproxPolyDP(contours[biggestContour], output, 10, true);


            LineSegment2D[] lines = { new LineSegment2D(output[0], output[1]), new LineSegment2D(output[1], output[2]),
                new LineSegment2D(output[2], output[3]),  new LineSegment2D(output[3], output[0]) };
            LineSegment2D baseLine = lines[0];
            LineSegment2D topLine = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].P2.Y < baseLine.P2.Y)
                {
                    baseLine = lines[i];
                }
                //****^^^^ gets wrong line
            }
            CvInvoke.Line(contourImage, baseLine.P1, baseLine.P2, new MCvScalar(0, 255, 0), 10);

            if (player.Y <= baseLine.P2.Y)
            {
                player.Y = baseLine.P2.Y;
            }

            player.Y -= speed;
            imageBox2.Image = paper;
            imageBox1.Image = contourImage;
        }

        private void camera_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.OrangeRed, player);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Right)
            {
                player.X -= speed;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Left)
            {
                player.X += speed;
            }
            if (e.KeyCode == Keys.Space)
            {

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
