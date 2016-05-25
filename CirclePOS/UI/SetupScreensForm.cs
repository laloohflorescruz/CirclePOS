using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class SetupScreensForm : Form
    {
        public SetupScreensForm()
        {
            InitializeComponent();
        }

        private void SetupScreensForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                customerScreenList.Items.Add("Display " + (i + 1).ToString());
                mainControlScreenList.Items.Add("Display " + (i + 1).ToString());
            }


            if (Program.theClientSetup.controlScreenNumber < mainControlScreenList.Items.Count)
                mainControlScreenList.SelectedIndex = Program.theClientSetup.controlScreenNumber;
            else
                mainControlScreenList.SelectedIndex = 0;
            if (Program.theClientSetup.customerScreenNumber < customerScreenList.Items.Count)
            {
                customerScreenList.SelectedIndex = Program.theClientSetup.customerScreenNumber;
                customerScreenEnableBox.Checked = true;
            }
            else
            {
                customerScreenList.SelectedIndex = 0;
                customerScreenEnableBox.Checked = false;

            }

            playInterfaceSoundsBox.Checked = Program.theClientSetup.playInterfaceSounds;
            advertisingBox.Text = Program.theDatabase.advertising;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (customerScreenEnableBox.Checked)
                Program.theClientSetup.customerScreenNumber = customerScreenList.SelectedIndex;
            else
                Program.theClientSetup.customerScreenNumber = -1;
            Program.theClientSetup.controlScreenNumber = mainControlScreenList.SelectedIndex;
                
            Program.theClientSetup.playInterfaceSounds = playInterfaceSoundsBox.Checked;
            Program.theDatabase.advertising = advertisingBox.Text;
            Program.theDatabase.saveToDisk();
            Program.theClientSetup.saveToFile();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
