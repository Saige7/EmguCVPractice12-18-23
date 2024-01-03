using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguCVPractice12_18_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        } 

        private void OrButton_Click(object sender, EventArgs e)
        {
            /*
            Bitmap image1 = Image.FromFile("Images/square.png") as Bitmap;
            Bitmap image2 = Image.FromFile("Images/bar.png") as Bitmap;
            Bitmap resultOfOr = image1;

            for (int x = 0; x < image1.Height; x++)
            {
                for (int y = 0; y < image1.Width; y++)
                {
                    var image1PixelColor = image1.GetPixel(x, y);
                    var image2PixelColor = image2.GetPixel(x, y);
                    var newColorInt = image1PixelColor.ToArgb() | image2PixelColor.ToArgb();
                    Color newColor = Color.FromArgb(newColorInt);
                   
                    resultOfOr.SetPixel(x, y, newColor);
                }
            }
            pictureBox3.Image = resultOfOr;
            */
            Stopwatch stopwatch = Stopwatch.StartNew();

            Mat image1 = imageBox1.Image as Mat;
            Mat image2 = imageBox2.Image as Mat;

            Mat output = new Mat();
            CvInvoke.BitwiseOr(image1, image2, output);

            imageBox3.Image = output;

            stopwatch.Stop();
        }
        private void AndButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox1.Image as Mat;
            Mat image2 = imageBox2.Image as Mat;

            Mat output = new Mat();
            CvInvoke.BitwiseAnd(image1, image2, output);

            imageBox3.Image = output;
        }
        private void XorButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox1.Image as Mat;
            Mat image2 = imageBox2.Image as Mat;

            Mat output = new Mat();
            CvInvoke.BitwiseXor(image1, image2, output);

            imageBox3.Image = output;
        }        
        private void NotButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox9.Image as Mat;

            Mat output = new Mat();
            CvInvoke.BitwiseNot(image1, output);

            imageBox10.Image = output;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox1.Image as Mat;
            Mat image2 = imageBox2.Image as Mat;

            Mat output = new Mat();
            CvInvoke.Add(image1, image2, output);

            imageBox3.Image = output;
        }


        private void Clockwise90Button_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox7.Image as Mat;
            CvInvoke.Rotate(image1, image1, RotateFlags.Rotate90Clockwise);
            imageBox8.Image = image1;
        }
        private void CounterClockwise90Button_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox7.Image as Mat;
            CvInvoke.Rotate(image1, image1, RotateFlags.Rotate90CounterClockwise);
            imageBox8.Image = image1;
        }
        private void Rotation180Button_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox7.Image as Mat;
            CvInvoke.Rotate(image1, image1, RotateFlags.Rotate180);
            imageBox8.Image = image1;
        }
        private void HorizontalFlipButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox7.Image as Mat;
            CvInvoke.Flip(image1, image1, FlipType.Horizontal);
            imageBox8.Image = image1;
        }
        private void VerticalFlipButton_Click(object sender, EventArgs e)
        {
            Mat image1 = imageBox7.Image as Mat;
            CvInvoke.Flip(image1, image1, FlipType.Vertical);
            imageBox8.Image = image1;
        }

        private void FlipHalfButton_Click(object sender, EventArgs e)
        {
            Mat fullImage = imageBox4.Image as Mat;
            Mat halfOfImage = new Mat(fullImage, new Rectangle(0, 0, fullImage.Width / 2, fullImage.Height));

            //CvInvoke.Rotate(halfImage, halfImage, RotateFlags.Rotate180);
            CvInvoke.Flip(halfOfImage, halfOfImage, FlipType.Horizontal);
            //Mat copyRegion = new Mat(fullImage, new Rectangle(0, 0, halfOfImage.Width, halfOfImage.Height));
            //halfOfImage.CopyTo(copyRegion);

            imageBox5.Image = fullImage;
        }


        private void Transformations_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Mat basicTriangle = CvInvoke.Imread("Images/triangle2.png");

                    Mat triangle1 = new Mat();
                    CvInvoke.BitwiseNot(basicTriangle, triangle1);
                    CvInvoke.Flip(triangle1, triangle1, FlipType.Vertical);

                    Mat triangle2 = new Mat();
                    CvInvoke.BitwiseNot(basicTriangle, triangle2);

                    Mat output = new Mat();
                    CvInvoke.BitwiseAnd(triangle1, triangle2, output);

                    imageBox6.Image = output;
                    break;

                case 1:
                    Mat circle = CvInvoke.Imread("Images/circle.png");
                    Mat bar = CvInvoke.Imread("Images/bar.png");

                    CvInvoke.BitwiseXor(circle, bar, circle);

                    CvInvoke.Rotate(bar, bar, RotateFlags.Rotate90Clockwise);
                    CvInvoke.BitwiseXor(circle, bar, circle);

                    imageBox6.Image = circle;
                    break;

                case 2:
                    Mat square = CvInvoke.Imread("Images/square.png");
                    Mat triangle = CvInvoke.Imread("Images/triangle.png");
                    Mat bar2 = CvInvoke.Imread("Images/bar.png");

                    CvInvoke.BitwiseAnd(square, bar2, bar2);

                    CvInvoke.BitwiseAnd(square, triangle, square);
                    CvInvoke.Flip(triangle, triangle, FlipType.Horizontal);
                    CvInvoke.BitwiseOr(square, triangle, square);
                    CvInvoke.BitwiseNot(square, square);

                    CvInvoke.BitwiseOr(square, bar2, square);

                    imageBox6.Image = square;
                    break;

                case 3:
                    Mat square2 = CvInvoke.Imread("Images/square.png");
                    Mat smallerSquare = new Mat();

                    CvInvoke.Resize(square2, smallerSquare, new Size(square2.Width / 4, square2.Height / 4));

                    Mat copyRegion = new Mat(square2, new Rectangle((square2.Width / 2) - (smallerSquare.Width / 2),
                        (square2.Height / 2) - (smallerSquare.Height / 2), smallerSquare.Width, smallerSquare.Height));

                    smallerSquare.CopyTo(copyRegion);

                    imageBox6.Image = square2;
                    break;

                case 4:
                    Mat circle2 = CvInvoke.Imread("Images/circle.png");
                    Mat triangle3 = CvInvoke.Imread("Images/triangle2.png");
                    Mat bar3 = CvInvoke.Imread("Images/bar.png");
                    Mat square3 = CvInvoke.Imread("Images/square.png");

                    CvInvoke.Rotate(bar3, bar3, RotateFlags.Rotate90Clockwise);

                    CvInvoke.BitwiseOr(circle2, bar3, circle2);
                    CvInvoke.BitwiseAnd(square3, bar3, square3);
                    CvInvoke.BitwiseXor(circle2, square3, circle2);
                    CvInvoke.BitwiseXor(circle2, triangle3, circle2);

                    imageBox6.Image = circle2;
                    break;

                case 5:
                    Mat circle3 = CvInvoke.Imread("Images/circle.png");

                    Mat invertedCircle = new Mat();
                    CvInvoke.Resize(circle3, invertedCircle, new Size(circle3.Width / 2, circle3.Height / 2));
                    CvInvoke.BitwiseNot(invertedCircle, invertedCircle);

                    Mat copyRegion2 = new Mat(circle3, new Rectangle((circle3.Width / 2) - (invertedCircle.Width / 2),
                        (circle3.Height / 2) - (invertedCircle.Height / 2), invertedCircle.Width, invertedCircle.Height));
                    invertedCircle.CopyTo(copyRegion2);

                    Mat smallCircle = new Mat();
                    CvInvoke.Resize(circle3, smallCircle, new Size(invertedCircle.Width / 2, invertedCircle.Height / 2));

                    Mat newCopyRegion = new Mat(circle3, new Rectangle((circle3.Width / 2) - (smallCircle.Width / 2),
                        (circle3.Height / 2) - (smallCircle.Height / 2), smallCircle.Width, smallCircle.Height));
                    smallCircle.CopyTo(newCopyRegion);

                    Mat final = new Mat();
                    CvInvoke.Resize(circle3, final, new Size(smallCircle.Width / 4, smallCircle.Height / 4));

                    Mat finalCopyRegion = new Mat(circle3, new Rectangle((circle3.Width / 2) - (final.Width / 2),
                        (circle3.Height / 2) - (final.Height / 2), final.Width, final.Height));
                    final.CopyTo(finalCopyRegion);

                    imageBox6.Image = circle3;
                    break;
            }
        }


        private void splitColor_Click(object sender, EventArgs e)
        {
            Mat imageToSplit = imageBox11.Image as Mat;
            Mat imageToSplitHSV = new Mat();
            CvInvoke.CvtColor(imageToSplit, imageToSplitHSV, ColorConversion.Bgr2Hsv);

            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(imageToSplitHSV, channels);

            Mat blue = new Mat();
            blue = channels[0].Clone();
            blueBox.Image = blue;

            Mat red = new Mat();
            red = channels[2].Clone();
            redBox.Image = red;

            Mat green = new Mat();
            green = channels[1].Clone();
            greenBox.Image = green;
        }

        private void RedButton_Click(object sender, EventArgs e)
        {
            Mat imageToSplit = imageBox11.Image as Mat;
            Mat imageToSplitHSV = new Mat();
            CvInvoke.CvtColor(imageToSplit, imageToSplitHSV, ColorConversion.Bgr2Hsv);

            Mat red = new Mat();
            CvInvoke.InRange(imageToSplitHSV, (ScalarArray) new MCvScalar(0, 100, 100), (ScalarArray) new MCvScalar(7, 255, 255), red);
            Mat red2 = new Mat();
            CvInvoke.InRange(imageToSplitHSV, (ScalarArray) new MCvScalar(150, 100, 100), (ScalarArray) new MCvScalar(180, 255, 255), red2);
            CvInvoke.Add(red, red2, red);

            blueBox.Image = red;
            greenBox.Image = null;
            redBox.Image = null;
        }
        private void GreenButton_Click(object sender, EventArgs e)
        {
            Mat imageToSplit = imageBox11.Image as Mat;
            Mat imageToSplitHSV = new Mat();
            CvInvoke.CvtColor(imageToSplit, imageToSplitHSV, ColorConversion.Bgr2Hsv);

            Mat green = new Mat();
            CvInvoke.InRange(imageToSplitHSV, (ScalarArray) new MCvScalar(40, 100, 100), (ScalarArray) new MCvScalar(80, 255, 255), green);
            
            blueBox.Image = green;
            greenBox.Image = null;
            redBox.Image = null;
        }
        private void BlueButton_Click(object sender, EventArgs e)
        {
            Mat imageToSplit = imageBox11.Image as Mat;
            Mat imageToSplitHSV = new Mat();
            CvInvoke.CvtColor(imageToSplit, imageToSplitHSV, ColorConversion.Bgr2Hsv);

            Mat blue = new Mat();
            CvInvoke.InRange(imageToSplitHSV, (ScalarArray) new MCvScalar(80, 100, 100), (ScalarArray) new MCvScalar(125, 255, 255), blue);
            
            blueBox.Image = blue;
            greenBox.Image = null;
            redBox.Image = null;
        }
        private void ShowColor_Scroll(object sender, EventArgs e)
        {
            Mat image = imageBox11.Image as Mat;
            Mat imageHSV = new Mat();
            CvInvoke.CvtColor(image, imageHSV, ColorConversion.Bgr2Hsv);

            Mat imageShown = new Mat();
            CvInvoke.InRange(imageHSV, (ScalarArray) new MCvScalar(0, 100, 100), (ScalarArray) new MCvScalar(showColorBar.Value, 255, 255), imageShown);
            HueNumber.Text = $"{showColorBar.Value}";

            blueBox.Image = imageShown;
            greenBox.Image = null;
            redBox.Image = null;
        }


        private void imageBox11_Click(object sender, EventArgs e)
        {
            blueBox.Image = null;
            greenBox.Image = null;
            redBox.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox11.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox9_Click(object sender, EventArgs e)
        {
            imageBox10.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox9.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox7_Click(object sender, EventArgs e)
        {
            imageBox8.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox7.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox4_Click(object sender, EventArgs e)
        {
            imageBox5.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox4.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox1_Click(object sender, EventArgs e)
        {
            imageBox3.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox1.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox2_Click(object sender, EventArgs e)
        {
            imageBox3.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox2.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox12_Click(object sender, EventArgs e)
        {
            imageBox14.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox12.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox13_Click(object sender, EventArgs e)
        {
            imageBox14.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox13.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox15_Click(object sender, EventArgs e)
        {
            imageBox16.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox15.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox17_Click(object sender, EventArgs e)
        {
            imageBox18.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox17.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        private void imageBox19_Click(object sender, EventArgs e)
        {
            imageBox20.Image = null;
            OpenFileDialog imageOpened = new OpenFileDialog();
            imageOpened.ShowDialog();
            imageBox19.Image = CvInvoke.Imread(imageOpened.FileName);
        }
        
        private void greenScreenButton_Click(object sender, EventArgs e)
        {
            Mat greenScreenImage = imageBox12.Image as Mat;
            Mat differentSizeBackground = imageBox13.Image as Mat;
            Mat backgroundImage = new Mat();
            CvInvoke.Resize(differentSizeBackground, backgroundImage, new Size(greenScreenImage.Width, greenScreenImage.Height));

            CvInvoke.CvtColor(greenScreenImage, greenScreenImage, ColorConversion.Bgr2Hsv);
            Mat green = new Mat();
            CvInvoke.InRange(greenScreenImage, (ScalarArray) new MCvScalar(40, 100, 100), (ScalarArray) new MCvScalar(80, 255, 255), green);
            CvInvoke.CvtColor(green, green, ColorConversion.Gray2Bgr);

            Mat backgroundOutput = new Mat();
            CvInvoke.BitwiseAnd(green, backgroundImage, backgroundOutput);

            Mat notGreen = new Mat();
            CvInvoke.BitwiseNot(green, notGreen);

            Mat greenScreenOutput = new Mat();
            CvInvoke.BitwiseAnd(notGreen, greenScreenImage, greenScreenOutput);
            CvInvoke.CvtColor(greenScreenOutput, greenScreenOutput, ColorConversion.Hsv2Bgr);

            Mat final = new Mat();
            CvInvoke.Add(greenScreenOutput, backgroundOutput, final);

            imageBox14.Image = final;
        }
        private void blueScreenButton_Click(object sender, EventArgs e)
        {
            Mat blueScreenImage = imageBox12.Image as Mat;
            Mat differentSizeBackground = imageBox13.Image as Mat;
            Mat backgroundImage = new Mat();
            CvInvoke.Resize(backgroundImage, backgroundImage, new Size(blueScreenImage.Width, blueScreenImage.Height));

            CvInvoke.CvtColor(blueScreenImage, blueScreenImage, ColorConversion.Bgr2Hsv);
            Mat blue = new Mat();
            CvInvoke.InRange(blueScreenImage, (ScalarArray) new MCvScalar(80, 100, 100), (ScalarArray) new MCvScalar(125, 255, 255), blue);
            CvInvoke.CvtColor(blue, blue, ColorConversion.Gray2Bgr);

            Mat backgroundOutput = new Mat();
            CvInvoke.BitwiseAnd(blue, backgroundImage, backgroundOutput);

            Mat notBlue = new Mat();
            CvInvoke.BitwiseNot(notBlue, notBlue);

            Mat blueScreenOutput = new Mat();
            CvInvoke.BitwiseAnd(notBlue, blueScreenImage, blueScreenOutput);
            CvInvoke.CvtColor(blueScreenOutput, blueScreenOutput, ColorConversion.Hsv2Bgr);

            Mat final = new Mat();
            CvInvoke.Add(blueScreenOutput, backgroundOutput, final);

            imageBox14.Image = final;
        }


        private void blurButton_Click(object sender, EventArgs e)
        {
            Mat imageToBlur = imageBox15.Image as Mat;

            switch (borderType.SelectedIndex)
            {
                case 0:
                    CvInvoke.Blur(imageToBlur, imageToBlur, new Size(int.Parse(kernelSize.Text), int.Parse(kernelSize.Text)), 
                        new Point(-1, -1), BorderType.Constant);
                    break;
                case 1:
                    CvInvoke.Blur(imageToBlur, imageToBlur, new Size(int.Parse(kernelSize.Text), int.Parse(kernelSize.Text)),
                        new Point(-1, -1), BorderType.Replicate);
                    break;
                case 2:
                    CvInvoke.Blur(imageToBlur, imageToBlur, new Size(int.Parse(kernelSize.Text), int.Parse(kernelSize.Text)),
                        new Point(-1, -1), BorderType.Reflect);
                    break;
                case 3:
                    CvInvoke.Blur(imageToBlur, imageToBlur, new Size(int.Parse(kernelSize.Text), int.Parse(kernelSize.Text)), 
                        new Point(-1, -1), BorderType.Reflect101);
                    break;
                case 4:
                    CvInvoke.Blur(imageToBlur, imageToBlur, new Size(int.Parse(kernelSize.Text), int.Parse(kernelSize.Text)), 
                        new Point(-1, -1), BorderType.Isolated);
                    break;
            }

            imageBox16.Image = imageToBlur;
        }
        private void blur(int kernelSize)
        {
            Bitmap imageToBlur = Image.FromFile("Images/blur1.png") as Bitmap;

            int[,] matrix = new int[kernelSize, kernelSize];
            for (int x = 0; x < imageToBlur.Width; x++)
            {
                for (int y = 0; y < imageToBlur.Height; y++)
                {
                    int numToDivideBy = 0;
                    int sum = 0;

                    for(int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            //x,y center point
                            if (imageToBlur.GetPixel(x - (kernelSize / 2) + i, y - (kernelSize / 2) + j) != null)
                            {
                                numToDivideBy++;
                                sum += imageToBlur.GetPixel(x - (kernelSize / 2) + i, y - (kernelSize / 2) + j).ToArgb();
                            }
                        }
                    }

                    int average = sum / numToDivideBy;
                    Color newColor = Color.FromArgb(average);
                    imageToBlur.SetPixel(x, y, newColor);

                }
            }

            pictureBox1.Image = imageToBlur;
        }


        private void findContours_Click(object sender, EventArgs e)
        {
            Mat contourImage = imageBox17.Image as Mat;
            Mat savedImage = contourImage.Clone();
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(contourImage, grayImage, ColorConversion.Bgr2Gray);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(grayImage, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);

            switch (colorOfContour.SelectedIndex)
            {
                case 0:
                    CvInvoke.DrawContours(savedImage, contours, -1, new MCvScalar(0, 0, 255), int.Parse(thickness.Text));
                    break;
                case 1:
                    CvInvoke.DrawContours(savedImage, contours, -1, new MCvScalar(0, 255, 0), int.Parse(thickness.Text));
                    break;
                case 2:
                    CvInvoke.DrawContours(savedImage, contours, -1, new MCvScalar(255, 0, 0), int.Parse(thickness.Text));
                    break;
            }
            imageBox18.Image = savedImage;
        }

        private void AreaAndPerimeter_Click(object sender, EventArgs e)
        {
            Mat contourImage = imageBox17.Image as Mat;
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(contourImage, grayImage, ColorConversion.Bgr2Gray);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(grayImage, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);

            var datatable = new DataTable();
            datatable.Columns.Add("Shape");
            datatable.Columns.Add("Area");
            datatable.Columns.Add("Perimeter");

            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i], false);
                double perimeter = CvInvoke.ArcLength(contours[i], true);
                string shape = "";

                for (int j = 0; j < contours.Size; j++)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    CvInvoke.Rectangle(contourImage, rect, new MCvScalar(0, 255, 255), 3);
                    shape = checkShape(contours[i], area, perimeter, rect.Width, rect.Height);
                    //bound rect is bigger than contour area
                    //so detect if it's close 
                }
                
                var row = datatable.NewRow();
                row["Shape"] = shape;
                row["Area"] = area;
                row["Perimeter"] = perimeter;
                datatable.Rows.Add(row);
            }

            contourInfo.DataSource = datatable;
        }
        private string checkShape(VectorOfPoint contour, double area, double perimeter, int width, int height)
        {
            double test = Math.PI * Math.Pow(width / 2, 2);
            double test2 = Math.PI * 2 * (width / 2);
            double test3 = 2 * (width + height);
            double test4 = width * height;

            if (area == Math.PI * Math.Pow(width / 2, 2) && perimeter == Math.PI * 2 * (width / 2))
            {
                return "circle";
            }
            else if (perimeter == 2 * (width + height) && area == width * height)
            {
                return "rectangle";
            }
            else
            {
                return "polygon";
            }          
        }


        private void DilateButton_Click(object sender, EventArgs e)
        {
            Mat image = imageBox19.Image as Mat;
            Mat output = new Mat();
            int kernelSize = int.Parse(otherKernelSize.Text);

            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(kernelSize, kernelSize), new Point(-1, -1));
            CvInvoke.Dilate(image, output, element, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(0, 0, 0));

            imageBox20.Image = output;
        }
        private void ErosionButton_Click(object sender, EventArgs e)
        {
            Mat image = imageBox19.Image as Mat;
            Mat output = new Mat();
            int kernelSize = int.Parse(otherKernelSize.Text);

            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(kernelSize, kernelSize), new Point(-1, -1));
            CvInvoke.Erode(image, output, element, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(0, 0, 0));

            imageBox20.Image = output;
        }

    }
}
