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
    public partial class EffectsBox : Form
    {
        public EffectsBox()
        {
            InitializeComponent();            
        }

        public EffectsBox(System.Windows.Forms.PictureBox openedImage)
        {
            InitializeComponent();
            affectedImage.Image = openedImage.Image;
            System.Drawing.Bitmap image = (Bitmap) affectedImage.Image;
            AForge.Imaging.Filters.Sepia filter = new AForge.Imaging.Filters.Sepia();
            affectedImage.Image = filter.Apply(image);
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
