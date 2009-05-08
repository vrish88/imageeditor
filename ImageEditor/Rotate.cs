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
    public partial class Rotate : Form
    {
        public Rotate()
        {
            InitializeComponent();
        }

        public int Degrees { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Degrees = Convert.ToInt16(degrees.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
