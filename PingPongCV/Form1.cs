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

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;

            computer = new Rectangle(5, pictureBox1.Height / 2 - 40, 20, 80);
            player = new Rectangle(pictureBox1.Width - 25, pictureBox1.Height / 2 - 40, 20, 80);
            ball = new Rectangle(pictureBox1.Width / 2, pictureBox1.Height / 2, 20, 20);

            xSpeed = 5;
            ySpeed = 5;
            computerSpeed = 10;
            paddleSpeed = 10;
            playerPoints = 0;
            computerPoints = 0;
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
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

            computerScore.Text = $"{computerPoints}";
            playerScore.Text = $"{playerPoints}";

            if (ball.Y <= 0 || ball.Y >= pictureBox1.Height)
            {
                ySpeed *= -1;
            }

            ball.X += xSpeed;
            ball.Y += ySpeed;

            if (computer.Bottom >= pictureBox1.Height || computer.Top <= 0)
            {
                computerSpeed *= -1;
            }

            computer.Y += computerSpeed;

            if (ball.IntersectsWith(player))
            {
                ball.X -= 5;
                xSpeed *= -1;
            }
            if (ball.IntersectsWith(computer))
            {
                ball.X += 5;
                xSpeed *= -1;
            }

            pictureBox1.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (player.Bottom <= pictureBox1.Height)
                {
                    player.Y += paddleSpeed;
                }
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (player.Top >= 0)
                {
                    player.Y -= paddleSpeed;
                }
            }
        }

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
