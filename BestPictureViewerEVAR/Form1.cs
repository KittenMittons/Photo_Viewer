using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestPictureViewerEVAR
{
    public partial class Form1 : Form
    {
        private Bitmap Image;
        public Form1()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.tiff; *.bmp))|*.png; *.jpg; *.jpeg; *.gif; *.tiff; *.bmp|All files (*.*)|*.*";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Image      = new Bitmap(filePath);
                pictureBox.Height = Image.Height;
                pictureBox.Width  = Image.Width;
                this.Height       = Image.Height;
                this.Width        = Image.Width;

                pictureBox.Image  = Image;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int xCenter, yCenter;
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                pictureBox.Height = Image.Height;
                pictureBox.Width = Image.Width;
                xCenter = (this.Width / 2) - (Image.Width / 2);
                yCenter = (this.Height / 2) - (Image.Height / 2);
                pictureBox.Location = new Point(xCenter,yCenter);
            }
            else
            {
                pictureBox.Location = new Point(0, 24);
                pictureBox.Height = this.Height;
                pictureBox.Width = this.Width;
            }
        }
    }
}