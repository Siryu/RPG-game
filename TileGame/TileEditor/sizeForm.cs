using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileEditor
{
    public partial class sizeForm : Form
    {
        public bool OKPressed = false;

        public sizeForm()
        {
            InitializeComponent();
        }

        private void OKbutton_Click_1(object sender, EventArgs e)
        {
            OKPressed = true;
            Close();
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            OKPressed = false;
            Close();
        }
    }
}
