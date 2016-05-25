using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class EditSales : Form
    {
        public EditSales()
        {
            InitializeComponent();
            updateList();
        }
        void updateList()
        {
            salesListView.BeginUpdate();
            salesListView.Items.Clear();

            foreach (Model.Sale s in Program.theDatabase.salesSince(dateTimePicker1.Value))
            {
                ListViewItem i = new ListViewItem(s.totalAmount.ToString("c"));

                i.SubItems.Add(s.productIDs.Length.ToString());
                i.SubItems.Add(s.timeCompleted.ToString());

                i.Tag = s;

                salesListView.Items.Add(i);
            }
            for (int i = 0; i < salesListView.Items.Count; i++)
                if (salesListView.Items[i].Tag == selectedSale)
                    salesListView.SelectedIndices.Add(i);
            

            salesListView.EndUpdate();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateList();
        }

        private void salesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateItemList();
        }

        void updateItemList()
        {

            itemsListView.BeginUpdate();
            itemsListView.Items.Clear();

            if (salesListView.SelectedItems.Count > 0)
            {
                Model.Sale s = (Model.Sale)salesListView.SelectedItems[0].Tag;

                for (int i = 0; i < s.productNames.Length; i++)
                {
                    ListViewItem z = new ListViewItem(s.productNames[i]);
                    z.SubItems.Add(s.productCosts[i].ToString("c"));
                    z.Tag = Program.theDatabase.getProduct(s.productIDs[i]);
                    itemsListView.Items.Add(z);
                }
            }


            itemsListView.EndUpdate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (salesListView.SelectedItems.Count > 0)
            {
                Model.Sale s = ((Model.Sale)salesListView.SelectedItems[0].Tag);
                Program.theDatabase.removeSale(s);
                Program.theDatabase.saveToDisk();
                updateList();
            }
        }
        Model.Sale selectedSale = null;

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (itemsListView.SelectedItems.Count > 0 && salesListView.SelectedItems.Count > 0)
            {
                Model.Sale s = ((Model.Sale)salesListView.SelectedItems[0].Tag);

                s.removeProductIndex(itemsListView.SelectedIndices[0]);
                selectedSale = s;
                updateItemList();
                updateList();
                selectedSale = null;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.theDatabase.saveToDisk();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
