using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        private readonly EffectsBox childEffectsBox;

        public Form1()
        {
            InitializeComponent();
        }

        public static PictureBox openImage = new PictureBox();

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Documents and Settings\Administrator\My Documents\My Pictures";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.Filter = "All Files|*.*|Windows Bitmaps|*.bmp|JPEG Files|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String filename = openFileDialog1.FileName;
                ImageBoxInApp.Image = System.Drawing.Image.FromFile(filename);
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
            AForge.Imaging.Filters.Sepia filter = new AForge.Imaging.Filters.Sepia();
            ImageBoxInApp.Image = filter.Apply(image);
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EffectsBox effectsBox = new EffectsBox(ImageBoxInApp);
            effectsBox.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openImage = ImageBoxInApp;
        }
    }
}
