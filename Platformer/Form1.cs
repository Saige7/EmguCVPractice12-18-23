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
    public readonly struct HierarchyItem
    {
        /// <summary>
        /// The index of the next contour at this hierarchy level. 
        /// -1 if unavailable.
        /// </summary>
        public readonly int Next;
        /// <summary>
        /// The index of the previous contour at this hierarchy level. 
        /// -1 if unavailable.
        /// </summary>
        public readonly int Previous;
        /// <summary>
        /// The index of the first child contour at this hierarchy level. 
        /// -1 if unavailable.
        /// </summary>
        public readonly int FirstChild;
        /// <summary>
        /// The index of the parent contour at this hierarchy level. 
        /// -1 if unavailable.
        /// </summary>
        public readonly int Parent;

        public HierarchyItem(int next, int previous, int firstChild, int parent)
        {
            Next = next;
            Previous = previous;
            FirstChild = firstChild;
            Parent = parent;
        }
    }
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCapture capture;
        private Rectangle player;
        private int speed;
        private bool gravity;

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
            player = new Rectangle(50, 50, 10, 10);
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
            gravity = true;

            if (camera.Image == null)
            {
                return;
            }
            Mat currentFrame = camera.Image as Mat;

            using Mat frameHSV = new Mat();
            CvInvoke.CvtColor(currentFrame, frameHSV, ColorConversion.Bgr2Hsv);
            CvInvoke.Blur(frameHSV, frameHSV, new Size(14, 14), new Point(-1, -1), BorderType.Constant);

            using Mat paper = new Mat();
            CvInvoke.InRange(frameHSV, (ScalarArray)new MCvScalar(0, 0, 130), (ScalarArray)new MCvScalar(180, 60, 255), paper);

            using VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            using HierarchyMatrix hierarchy = new HierarchyMatrix();
            CvInvoke.FindContours(paper, contours, hierarchy, RetrType.Ccomp, ChainApproxMethod.ChainApproxNone);
            using Mat contourImage = currentFrame.Clone();
            CvInvoke.DrawContours(contourImage, contours, -1, new MCvScalar(255, 0, 100), 3);      

            int biggestContour = 0;
            if (contours.Size > 0)
            {
                double area = CvInvoke.ContourArea(contours[0], false);
                for (int i = 1; i < contours.Size; i++)
                {
                    if (CvInvoke.ContourArea(contours[i], false) > area)
                    {
                        area = CvInvoke.ContourArea(contours[i], false);
                        biggestContour = i;
                    }
                }
            }

            VectorOfPoint output = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(contours[biggestContour], output, 10, true);

            LineSegment2D[] lines = { new LineSegment2D(output[0], output[1]), new LineSegment2D(output[1], output[2]),
                new LineSegment2D(output[2], output[3]),  new LineSegment2D(output[3], output[0]) };
            LineSegment2D baseLine = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if ((lines[i].P2.Y > baseLine.P2.Y || lines[i].P1.Y > baseLine.P1.Y) && lines[i].P2.X > lines[i].P1.X)
                {
                    baseLine = lines[i];
                }
            }

            CvInvoke.Line(contourImage, baseLine.P1, baseLine.P2, new MCvScalar(100, 100, 255), 10);

            if (player.Y >= baseLine.P2.Y + 20 || player.Y >= baseLine.P1.Y + 20)
            {
                gravity = false;
            }
            if (player.Y > baseLine.P2.Y + 100 || player.Y > baseLine.P1.Y + 100)
            {
                player.Y = baseLine.P2.Y;
            }

            if (player.Y < 0)
            {
                player.Y = 0;
            }
            if (player.X < 0)
            {
                player.X = 0;
            }
            if (player.X + player.Width > 465)
            {
                player.X = 465 - player.Width;
            }

            //HierarchyItem firstSmallChild = hierarchy[hierarchy[biggestContour].FirstChild];

            //for (int i = 0; i != -1; i = firstSmallChild.Next)
            //{
            //    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

            //    //CvInvoke.Rectangle(contourImage, rect, new MCvScalar(0, 255, 255), 5);
            //    //var verticies = rect.GetVertices().Select(pt => new Point((int)pt.X, (int)pt.Y)).ToArray();
            //    //LineSegment2D[] sides = { new LineSegment2D(verticies[0], verticies[1]), new LineSegment2D(verticies[1], verticies[2]),
            //    //new LineSegment2D(verticies[2], verticies[3]),  new LineSegment2D(verticies[3], verticies[0]) };

            //    if (player.IntersectsWith(rect))
            //    {
            //        gravity = false;
            //    }
            //}

            for (int i = 0; i < contours.Size; i++)
            {
                if (i != biggestContour)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                    CvInvoke.Rectangle(contourImage, rect, new MCvScalar(255, 0, 0), 3);

                    if (player.IntersectsWith(rect))
                    {
                        gravity = false;
                        player.Y = rect.Y;
                    }
                    //bounding boxes are probably off - get hierarchy to work
                }
            }

            if (gravity == true)
            {
                player.Y += speed;
            }

            imageBox2.Image = paper;
            imageBox1.Image = contourImage;
        }

        private void camera_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.MediumVioletRed, player);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Right)
            {
                player.X += speed;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Left)
            {
                player.X -= speed;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (!(player.Y < 50))
                {
                    player.Y -= 50;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
