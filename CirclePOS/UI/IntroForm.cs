using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Enabled = false;
            this.Close();
        }
    }
}
