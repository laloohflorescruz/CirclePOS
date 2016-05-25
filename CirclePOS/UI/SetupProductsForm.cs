using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class SetupProductsForm : Form
    {
        public SetupProductsForm()
        {
            InitializeComponent();
            loadProducts();
            disableBoxes();
        }
        bool ignore = false;
        List<Model.Product> theProducts = new List<Model.Product>();
        void loadProducts()
        {
            theProducts = new List<Model.Product>(Program.theDatabase.allProducts);
            showProducts();
        }
        void showProducts(Model.Product select = null)
        {
            groupComboBox.Items.Clear();
            foreach (string s in Program.theDatabase.getAllGroups())
                groupComboBox.Items.Add(s);
            productsListView.BeginUpdate();
            productsListView.Items.Clear();

            ListViewItem toSelect=null;
            foreach (Model.Product p in theProducts)
            {
                if (!p.deleted)
                {
                    ListViewItem i = new ListViewItem();
                    i.Text = p.name;
                    i.Tag = p;
                    productsListView.Items.Add(i);

                    if (p == selectedProduct || p == select)
                        toSelect = i;
                }
            }

            productsListView.EndUpdate();
            if (toSelect != null)
                productsListView.SelectedIndices.Add(toSelect.Index);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Model.Product p = new Model.Product();
            p.name = "New Product";
            p.ID = Guid.NewGuid();
            theProducts.Add(p);
            showProducts(p);

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.theDatabase.allProducts = theProducts.ToArray();
            Program.theDatabase.saveToDisk();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Program.theDatabase = Model.Database.loadFromDisk();
            this.Close();
        }

        void disableBoxes()
        {
            replaceImageButton.Enabled = false;
            productNameBox.Enabled = false;
            productNameBox.Text = "";
            productImageBox.BackgroundImage = null;
            saleCostBox.Enabled = false;
            saleCostBox.Value = 0;
            barcodeInputBox.Text = "";
            barcodeInputBox.Enabled = false;
            stockLevelBox.Value = 0;
            stockLevelBox.Enabled = false;

        }
        Model.Product selectedProduct;
        private void productsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ignore = true;
            if (productsListView.SelectedItems.Count == 0)
            {

                disableBoxes();
            }
            else
            {
                Model.Product p = ((Model.Product)productsListView.SelectedItems[0].Tag);

                selectedProduct = p;

                groupComboBox.Text = p.group;

                productNameBox.Enabled = true;
                saleCostBox.Enabled = true;
                barcodeInputBox.Enabled = true;
                stockLevelBox.Enabled = true;
                replaceImageButton.Enabled = true;

                productNameBox.Text = p.name;
                productImageBox.BackgroundImage = null;
                saleCostBox.Value = p.cost;
                barcodeInputBox.Text = p.barcode;
                stockLevelBox.Value = p.stock;

                groupComboBox.Items.Clear();
                foreach (string s in Program.theDatabase.getAllGroups())
                    groupComboBox.Items.Add(s);
                
            if(System.IO.File.Exists(p.imagePath))
                try
                {
                    productImageBox.BackgroundImage = new Bitmap(p.imagePath);
                }
                catch
                {
                    productImageBox.BackgroundImage = null;
                }
            }
            ignore = false;
        }

        private void productNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignore && productsListView.SelectedItems.Count > 0)
            {
                ((Model.Product)productsListView.SelectedItems[0].Tag).name = productNameBox.Text;
                showProducts();
            }
        }

        private void saleCostBox_ValueChanged(object sender, EventArgs e)
        {
            if (!ignore && productsListView.SelectedItems.Count > 0)
            {
                ((Model.Product)productsListView.SelectedItems[0].Tag).cost = saleCostBox.Value;
            }
        }

        private void stockLevelBox_ValueChanged(object sender, EventArgs e)
        {

            if (!ignore && productsListView.SelectedItems.Count > 0)
            {
                ((Model.Product)productsListView.SelectedItems[0].Tag).stock = (int)stockLevelBox.Value;
            }
        }

        private void barcodeInputBox_TextChanged(object sender, EventArgs e)
        {

            if (!ignore && productsListView.SelectedItems.Count > 0)
            {
                ((Model.Product)productsListView.SelectedItems[0].Tag).barcode = barcodeInputBox.Text;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (!ignore && productsListView.SelectedItems.Count > 0)
            {
                ((Model.Product)productsListView.SelectedItems[0].Tag).deleted = true;
                showProducts();
                disableBoxes();
            }
        }

        private void replaceImageButton_Click(object sender, EventArgs e)
        {
            openImageDialog.FileName = "";
            openImageDialog.ShowDialog();

            if (System.IO.File.Exists(openImageDialog.FileName))
            {
                selectedProduct.setImage(openImageDialog.FileName);
                try
                {
                    productImageBox.BackgroundImage = new Bitmap(openImageDialog.FileName);
                }
                catch
                {
                    productImageBox.BackgroundImage = null;
                }
            }
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct.group = groupComboBox.Text;
        }

        private void groupComboBox_TextChanged(object sender, EventArgs e)
        {
            selectedProduct.group = groupComboBox.Text;
        }

        private void SetupProductsForm_Load(object sender, EventArgs e)
        {
            Program.theDatabase.saveToDisk();
        }

    }
}
