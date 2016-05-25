using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class SetupPasscodesForm : Form
    {
        public SetupPasscodesForm()
        {
            InitializeComponent();
            newSellCode = Program.theDatabase.salesLockCode;
            newAdminCode = Program.theDatabase.adminLockCode;
            ignore = true;
            if (Program.theDatabase.salesLockCode != "")
                requireCodeToSellBox.Checked = true;
            else
                requireCodeToSellBox.Checked = false;
            if (Program.theDatabase.adminLockCode != "")
                requireCodeForAdminBox.Checked = true;
            else
                requireCodeForAdminBox.Checked = false;
            if (Program.theDatabase.giftLockCode != "")
                requireCodeToGiftBox.Checked = true;
            else
                requireCodeToGiftBox.Checked = false;
            ignore = false;
        }

        string newAdminCode = "";
        string newSellCode = "";
        string newGiftCode = "";
        bool ignore = false;
        private void changeSalesCodeButton_Click(object sender, EventArgs e)
        {
            showSalesCodeEntry();
        }
        void showAdminCodeEntry()
        {
            PasscodeForm f = new PasscodeForm();
            f.ShowDialog();

            if (f.cancel == false)
            {
                PasscodeForm f2 = new PasscodeForm();
                f2.ShowDialog();

                if (f2.cancel == false)
                {
                    if (f.codedInputResult == f2.codedInputResult)
                    {
                        ignore = true;
                        requireCodeForAdminBox.Checked = true;
                        ignore = false;
                        newAdminCode = f.codedInputResult;
                    }
                    else
                        MessageBox.Show("Error - those two codes were not the same.");
                }
            }
        }
        void showSalesCodeEntry()
        {


            PasscodeForm f = new PasscodeForm();
            f.ShowDialog();

            if (f.cancel == false)
            {
                PasscodeForm f2 = new PasscodeForm();
                f2.ShowDialog();

                if (f2.cancel == false)
                {
                    if (f.codedInputResult == f2.codedInputResult)
                    {
                        ignore = true;
                        requireCodeToSellBox.Checked = true;
                        ignore = false;
                        newSellCode = f.codedInputResult;
                    }
                    else
                        MessageBox.Show("Error - those two codes were not the same.");
                }
            }
        }

        void showGiftCodeEntry()
        {


            PasscodeForm f = new PasscodeForm();
            f.ShowDialog();

            if (f.cancel == false)
            {
                PasscodeForm f2 = new PasscodeForm();
                f2.ShowDialog();

                if (f2.cancel == false)
                {
                    if (f.codedInputResult == f2.codedInputResult)
                    {
                        ignore = true;
                        requireCodeToGiftBox.Checked = true;
                        ignore = false;
                        newGiftCode = f.codedInputResult;
                    }
                    else
                        MessageBox.Show("Error - those two codes were not the same.");
                }
            }
        }

        private void requireCodeToSellBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ignore)
            {
                if (requireCodeToSellBox.Checked == false)
                {
                    newSellCode = "";

                }
                else
                {

                    showSalesCodeEntry();

                }
            }
        }

        private void requireCodeForAdminBox_CheckedChanged(object sender, EventArgs e)
        {

            if (!ignore)
            {
                if (requireCodeForAdminBox.Checked == false)
                {
                    newAdminCode = "";
                }
                else
                {

                    showAdminCodeEntry();

                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.theDatabase.adminLockCode = newAdminCode;
            Program.theDatabase.salesLockCode = newSellCode;
            Program.theDatabase.giftLockCode = newGiftCode;
            Program.theDatabase.alteredSinceLastSave = true;
            Program.theDatabase.saveToDisk();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeAdminCodeButton_Click(object sender, EventArgs e)
        {
            showAdminCodeEntry();
        }

        private void changeGiftCodeButton_Click(object sender, EventArgs e)
        {
            showGiftCodeEntry();

        }

        private void requireCodeToGiftBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ignore)
            {
                if (requireCodeToGiftBox.Checked == false)
                {
                    newGiftCode = "";
                }
                else
                {

                    showGiftCodeEntry();

                }
            }

        }
    }
}
