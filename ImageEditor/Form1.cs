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
using System.IO;

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
            this.rToolStripMenuItem.Enabled = value;
            this.undoToolStripMenuItem.Enabled = value;
            this.resizeToolStripMenuItem.Enabled = value;
            this.rotateToolStripMenuItem.Enabled = value;
        }

        public static PictureBox openImage = new PictureBox();

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public String filename { get; set; }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Documents and Settings\Administrator\My Documents\My Pictures";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.Filter = "All Files|*.*|Windows Bitmaps|*.bmp|JPEG Files|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                Image img = System.Drawing.Image.FromFile(filename);
                MemoryStream imgStream = new MemoryStream();
                img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Bmp);
                int h = img.Height;
                int w = img.Width;
                adjustWindow(w, h);
                ImageBoxInApp.Image = System.Drawing.Image.FromStream(imgStream);
                img.Dispose();
                changeMenuOptions(true);
                RChanges.Clear();
                UChanges.Clear();
            }
        }

        public void adjustWindow(int width, int height)
        {
            if (height > this.Height)
            {
                ImageBoxInApp.Height = height;
                this.Height = height;
            }
            if (width > this.Width)
            {
                ImageBoxInApp.Width = width;
                this.Width = width;
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
            System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
            ImageBoxInApp.Image = image.ToBlackAndWhite();
            RChanges.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openImage = ImageBoxInApp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename == "")
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
                    else
                    {
                        filename = Save.FileName;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }

            // Delete existing file first
            System.IO.File.Delete(filename);
            // then save it
            ImageBoxInApp.Image.Save(filename);
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

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resize resizeForm = new resize();
            if (resizeForm.ShowDialog() == DialogResult.OK)
            {
                UCAdd(ImageBoxInApp.Image);
                System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
                ImageBoxInApp.Image = image.resize(resizeForm.Width, resizeForm.Height);
                adjustWindow(resizeForm.Width, resizeForm.Height);
                RChanges.Clear();
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate rotateForm = new Rotate();
            if (rotateForm.ShowDialog() == DialogResult.OK)
            {
                UCAdd(ImageBoxInApp.Image);
                System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
                ImageBoxInApp.Image = image.rotate(rotateForm.Degrees);
                adjustWindow(image.Width, image.Height);
                RChanges.Clear();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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

            if (filename == "")
            {
                return;
            }
            else if (Save.FileName.Contains(".jpg"))
            {
                ImageBoxInApp.Image.Save(Save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (Save.FileName.Contains(".png"))
            {
                ImageBoxInApp.Image.Save(Save.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                ImageBoxInApp.Image.Save(Save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            filename = Save.FileName;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gaussian gaussianForm = new Gaussian();
            if (gaussianForm.ShowDialog() == DialogResult.OK)
            {
                UCAdd(ImageBoxInApp.Image);
                System.Drawing.Bitmap image = (Bitmap)ImageBoxInApp.Image;
                ImageBoxInApp.Image = image.gaussianBlur(gaussianForm.blur);
                RChanges.Clear();
            }
        }
    }
}
