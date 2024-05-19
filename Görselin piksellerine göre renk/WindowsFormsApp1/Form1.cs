using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private Color CreateColor(Bitmap image, int step)
        {
            int Red = 0, Green = 0, Blue = 0, pixelCount = 0;

            for (int x = 0; x < image.Width; x += step)
            {
                for (int y = 0; y < image.Height; y += step)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    Red += pixelColor.R;
                    Green += pixelColor.G;
                    Blue += pixelColor.B;
                    pixelCount++;
                }
            }

            int mixedRed = Red / pixelCount;
            int mixedGreen = Green / pixelCount;
            int mixedBlue = Blue / pixelCount;

            return Color.FromArgb(mixedRed, mixedGreen, mixedBlue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                Color color = CreateColor(image, 100);
                label1.BackColor = color;
            }
        }
    }
}
