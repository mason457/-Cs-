using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace _11101
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap bmp1;
        Bitmap newbmp; 
        int[,] img;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);                //圖片像素資料存於變數bmp
                pictureBox1.Image = bmp;                                   //顯示於pictureBox1.
                img = test_a.BmpToAry.Transfer(bmp);                         //將相速資料置入test.BmpToAry.Transfer函式，輸出陣列img            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                newbmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);   //圖檔newbmp輸出
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                int HEIGHT = img.GetLength(0);
                int WIDTH = img.GetLength(1);
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        img[i, j] = 255-img[i, j];
                    }
                } 
                newbmp = test_a.BmpToAry.Invert(img);
                pictureBox2.Image = newbmp;
            }
            else
            {
                MessageBox.Show("請先載入圖形");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer, 每10ms讀取滑鼠座標值及像素顏色並顯示於 PictureBox背景
            Color color = GetPixelColor(Cursor.Position);
            labelx.Text = "X = " + Cursor.Position.X.ToString();
            labely.Text = "Y = " + Cursor.Position.Y.ToString();
            labelr.Text = " R = " + color.R;
            labelg.Text = " G = " + color.G;
            labelb.Text = " B = " + color.B;
            pictureBox1.BackColor = color;
        }
        static Color GetPixelColor(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }

        private void labela_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
