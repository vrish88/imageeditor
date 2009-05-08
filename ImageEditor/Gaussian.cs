using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Gaussian : Form
    {
        public Gaussian()
        {
            InitializeComponent();
        }

        public int blur { get; set; }

        private void okBtn_Click(object sender, EventArgs e)
        {
            blur = slider.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            amount.Text = Convert.ToString(slider.Value);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
