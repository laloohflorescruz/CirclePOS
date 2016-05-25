using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class GiftForm : Form
    {
        public GiftForm()
        {
            InitializeComponent();
        }

        private void GiftForm_Load(object sender, EventArgs e)
        {
            if(Program.theDatabase.giftLockCode != "")
                warningLabel.Text = "You must enter a passcode to continue. Are you sure?";
        }
        public bool success = false;
        private void yesButton_Click(object sender, EventArgs e)
        {
            if (Program.theDatabase.giftLockCode != "")
            {
                PasscodeForm f = new PasscodeForm();
                f.ShowDialog();

                if (f.cancel || f.codedInputResult != Program.theDatabase.giftLockCode)
                    return;
            }
            success = true;
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            success = false;
            this.Close();
        }
    }
}
