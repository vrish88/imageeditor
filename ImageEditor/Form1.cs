using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using ExtensionMethods;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        private readonly EffectsBox childEffectsBox;

        Stack<Image> UChanges = new Stack<Image>(5);
        Stack<Image> RChanges = new Stack<Image>(5);

        public Form1()
        {
            InitializeComponent();
            changeMenuOptions(false);
        }

        public void UCAdd(Image img)
        {
            UChanges.Push(img);
        }

        public void RCAdd(Image img)
        {
            RChanges.Push(img);
        }

        private void changeMenuOptions(bool value)
        {
            this.saveAsToolStripMenuItem.Enabled = value;
            this.sepiaToolStripMenuItem.Enabled = value;
            this.blackAndWhiteToolStripMenuItem.Enabled = value;
            this.blurToolStripMenuItem.Enabled = value;
            this.jitterToolStripMenuItem.Enabled = value;
            this.pixallateToolStripMenuItem.Enabled = value;
            this.saveToolStripMenuItem.Enabled = value;
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
                Image img = System.Drawing.Image.FromFile(filename);
                int h = img.Height;
                int w = img.Width;
                ImageBoxInApp.Height = h;
                ImageBoxInApp.Width = w;
                this.Height = h;
                this.Width = w;
                ImageBoxInApp.Image = img;
                changeMenuOptions(true);
                RChanges.Clear();
                UChanges.Clear();
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCAdd(ImageBoxInApp.Image);
            System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
            ImageBoxInApp.Image = image.ToSepia();
            RChanges.Clear();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCAdd(ImageBoxInApp.Image);
            EffectsBox effectsBox = new EffectsBox(ImageBoxInApp);
            effectsBox.ShowDialog();
            RChanges.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openImage = ImageBoxInApp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog();
            try
            {
                //Open a file dialog for saving map documents

                Save.Title = "Save";
                Save.Filter = "Please select a file type||Bitmap File (*.bmp)|*.bmp|JPEG file (*.jpg)|*.jpg|PNG file(*.png)|*.png";
                if (Save.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
            //Exit if no map document is selected
            string sFilePath;
            sFilePath = Save.FileName;
            if (sFilePath == "")
            {
                return;
            } 
            else if (Save.FileName.Contains(".jpg"))
            {
                ImageBoxInApp.Image.Save(sFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (Save.FileName.Contains(".png"))
            {
                ImageBoxInApp.Image.Save(sFilePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                ImageBoxInApp.Image.Save(sFilePath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
             
        }

        private void pixallateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCAdd(ImageBoxInApp.Image);
            System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
            ImageBoxInApp.Image = image.ToPixalation();
            RChanges.Clear();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UChanges.Count != 0)
            {
                RCAdd(ImageBoxInApp.Image);
                ImageBoxInApp.Image = UChanges.Pop();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RChanges.Count != 0)
            {
                UCAdd(ImageBoxInApp.Image);
                ImageBoxInApp.Image = RChanges.Pop();
            }
        }
    }
}
