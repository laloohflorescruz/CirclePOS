using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class CashForm : Form
    {
        public bool cancel = true;
        Decimal amountDue;
        public CashForm(Decimal amountDue)
        {
            this.amountDue = amountDue;
            InitializeComponent();
            amountDueLabel.Text = "Amount Due: " + amountDue.ToString("c");
            updateChange();
        }

        public Decimal change = 0.0m;

        private void completeButton_Click(object sender, EventArgs e)
        {
            cancel = false;
            this.Close();
        }


        private void exactChangeButton_Click(object sender, EventArgs e)
        {
            change = 0.0m;
            total = amountDue;
            cancel = false;
            this.Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        Decimal total=0;
        private void hundredDollarButton_Click(object sender, EventArgs e)
        {
            total += 100;
            cashProvidedBox.Items.Add("$100");
            updateChange();

        }

        private void fiftyDollarButton_Click(object sender, EventArgs e)
        {

            total += 50;
            cashProvidedBox.Items.Add("$50");
            updateChange();
        }

        private void twentyDollarButton_Click(object sender, EventArgs e)
        {

            total += 20;
            cashProvidedBox.Items.Add("$20");
            updateChange();
        }

        private void tenDollarButton_Click(object sender, EventArgs e)
        {

            total += 10;
            cashProvidedBox.Items.Add("$10");
            updateChange();
        }

        private void fiveDollarButton_Click(object sender, EventArgs e)
        {

            total += 5;
            cashProvidedBox.Items.Add("$5");
            updateChange();
        }

        private void twoDollarButton_Click(object sender, EventArgs e)
        {

            total += 2;
            cashProvidedBox.Items.Add("$2");
            updateChange();
        }

        private void oneDollarButton_Click(object sender, EventArgs e)
        {

            total += 1;
            cashProvidedBox.Items.Add("$1");
            updateChange();
        }

        private void fiftyCentsButton_Click(object sender, EventArgs e)
        {

            total += 0.50m;
            cashProvidedBox.Items.Add("50c");
            updateChange();
        }

        private void twentyCentsButton_Click(object sender, EventArgs e)
        {

            total += 0.20m;
            cashProvidedBox.Items.Add("20c");
            updateChange();
        }

        private void tenCentsButton_Click(object sender, EventArgs e)
        {

            total += 0.10m;
            cashProvidedBox.Items.Add("10c");
            updateChange();
        }

        private void fiveCentsButton_Click(object sender, EventArgs e)
        {

            total += 0.05m;
            cashProvidedBox.Items.Add("5c");
            updateChange();
        }

        void updateChange()
        {
            if (total < amountDue)
            {
                amountDueLabel.Text = "Amount Due: " + (amountDue - total).ToString("c");
                changeDueLabel.Text = "Change Due: $0.00";
                completeButton.Enabled = false;
                change = 0.0m;
            }
            else
            {
                amountDueLabel.Text = "Amount Due: $0.00";
                changeDueLabel.Text = "Change Due: " + (total - amountDue).ToString("c");
                completeButton.Enabled = true;
                change = total - amountDue;
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            cashProvidedBox.Items.Clear();
            total = 0;
            updateChange();
        }
    }
}
