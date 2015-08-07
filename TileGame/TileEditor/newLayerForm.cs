using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileEditor
{
    public partial class newLayerForm : Form
    {
        public bool OKPressed = false;
        
        
        public newLayerForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OKPressed = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OKPressed = false;
            Close();
        }
    }
}
