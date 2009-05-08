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
    public partial class resize : Form
    {
        public resize()
        {
            InitializeComponent();
        }

        public int Width { get; set; }
        public int Height { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Width = Convert.ToInt16(width.Text);
            Height = Convert.ToInt16(height.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
