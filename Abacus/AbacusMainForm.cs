using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abacus
{
    public partial class AbacusMainForm : Form
    {
        public AbacusMainForm()
        {
            InitializeComponent();

            beedColumns1.ValueChanged += new EventHandler(valueChanged);
            label1.Text = beedColumns1.getValue();
        }

        private void valueChanged(object sender, EventArgs e)
        {
            label1.Text = beedColumns1.getValue();
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beedColumns1.reset();
            label1.Text = beedColumns1.getValue();
        }
    }
}
