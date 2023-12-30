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

namespace PingPongCV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Rectangle player;
        private Rectangle computer;
        private Rectangle ball;

        private int paddleSpeed;
        private int computerSpeed;
        private int xSpeed;
        private int ySpeed;
        private int computerPoints;
        private int playerPoints;
        private VideoCapture capture;
        private Rectangle PaddleBounds1;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;

            computer = new Rectangle(5, pictureBox1.Height / 2 - 40, 20, 80);
            player = new Rectangle(pictureBox1.Width - 25, pictureBox1.Height / 2 - 40, 20, 80);
            ball = new Rectangle(pictureBox1.Width / 2, pictureBox1.Height / 2, 20, 20);

            xSpeed = 7;
            ySpeed = 7;
            computerSpeed = 10;
            paddleSpeed = 10;
            playerPoints = 0;
            computerPoints = 0;

            capture = new VideoCapture(0);

            Application.Idle += GrabFromIdle;
            
        }
        private void GrabFromIdle(object sender, EventArgs e)
        {
            if (!capture.Grab())
            {
                return;
            }
            using Mat originalCurrentFrame = capture.QueryFrame();
            camera.Image?.Dispose();
            Mat smallCurrentFrame = new Mat();
            CvInvoke.Resize(originalCurrentFrame, smallCurrentFrame, new Size(originalCurrentFrame.Width / 2, originalCurrentFrame.Height / 2));

            CvInvoke.Flip(smallCurrentFrame, smallCurrentFrame, FlipType.Horizontal);

            camera.Image = smallCurrentFrame;

            PaddleBounds1 = paddleDetection();

        }
        private Rectangle paddleDetection()
        {
            Mat smallCurrentFrame = camera.Image as Mat;

            using Mat currentFrameHSV = new Mat();
            CvInvoke.CvtColor(smallCurrentFrame, currentFrameHSV, ColorConversion.Bgr2Hsv);

            using Mat red = new Mat();
            CvInvoke.InRange(currentFrameHSV, (ScalarArray)new MCvScalar(0, 100, 100), (ScalarArray)new MCvScalar(7, 255, 255), red);
            using Mat red2 = new Mat();
            CvInvoke.InRange(currentFrameHSV, (ScalarArray)new MCvScalar(150, 100, 100), (ScalarArray)new MCvScalar(180, 255, 255), red2);
            CvInvoke.Add(red, red2, red);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            using Mat hierarchy = new Mat();
            CvInvoke.FindContours(red, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);

            Rectangle rect = new Rectangle();
            if (contours.Size > 0)
            {
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
                rect = CvInvoke.BoundingRectangle(contours[correctContour]);
                CvInvoke.Rectangle(smallCurrentFrame, rect, new MCvScalar(0, 255, 255), 2);
            }

            return rect;
        }

        private void paddleMovement(Rectangle paddleBounds)
        {
            if (player.Bottom <= pictureBox1.Height && player.Top >= 0)
            {
                player.Y = paddleBounds.Location.Y * 2;
            }
            if (player.Bottom >= pictureBox1.Height)
            {
                player.Y -= 5;
            }
            if (player.Top <= 0)
            {
                player.Y += 5;
            }

            if (player.Left >= 0 && player.Right <= pictureBox1.Width)
            {
                player.X = paddleBounds.Location.X * 3;
            }
            if (player.Left <= 0)
            {
                player.X += 5;
            }
            if (player.Right >= pictureBox1.Width)
            {
                player.X -= 5;
            }

        }
        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            paddleMovement(PaddleBounds1);

            if (computerPoints == 10 || playerPoints == 10)
            {
                playerPoints = 0;
                computerPoints = 0;

                ball.X = pictureBox1.Width / 2;
                ball.Y = pictureBox1.Height / 2;

                computer.X = 5;
                computer.Y = pictureBox1.Height / 2 - 40;

                player.X = pictureBox1.Width - 25;
                player.Y = pictureBox1.Height / 2 - 40;
            }

            computerScore.Text = $"{computerPoints}";
            playerScore.Text = $"{playerPoints}";

            if (ball.X <= 0)
            {
                playerPoints++;
                ball.X = pictureBox1.Width / 2;
                ball.Y = pictureBox1.Height / 2;
            }
            if (ball.X >= pictureBox1.Width - 25)
            {
                computerPoints++;
                ball.X = pictureBox1.Width / 2;
                ball.Y = pictureBox1.Height / 2;
            }

            if (ball.Y <= 0 || ball.Y >= pictureBox1.Height)
            {
                ySpeed *= -1;
            }

            if (ball.IntersectsWith(player))
            {
                ball.X -= 25;
                xSpeed *= -1;
            }
            if (ball.IntersectsWith(computer))
            {
                ball.X += 5;
                xSpeed *= -1;
            }

            ball.X += xSpeed;
            ball.Y += ySpeed;

            if (computer.Bottom >= pictureBox1.Height || computer.Top <= 0)
            {
                computerSpeed *= -1;
            }

            computer.Y += computerSpeed;

            pictureBox1.Refresh();
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
        //    {
        //        if (player.Bottom <= pictureBox1.Height)
        //        {
        //            player.Y += paddleSpeed;
        //        }
        //    }
        //    if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
        //    {
        //        if (player.Top >= 0)
        //        {
        //            player.Y -= paddleSpeed;
        //        }
        //    }
        //}

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.RoyalBlue, computer);
            e.Graphics.FillRectangle(Brushes.Red, player);
            e.Graphics.FillEllipse(Brushes.Black, ball);
        }


    }
}
