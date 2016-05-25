namespace CirclePOS.UI
{
    partial class SetupProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupProductsForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.productsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.barcodeInputBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.replaceImageButton = new System.Windows.Forms.Button();
            this.productImageBox = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.stockLevelBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.saleCostBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.productNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockLevelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleCostBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.addButton);
            this.splitContainer1.Panel1.Controls.Add(this.deleteButton);
            this.splitContainer1.Panel1.Controls.Add(this.productsListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.barcodeInputBox);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.replaceImageButton);
            this.splitContainer1.Panel2.Controls.Add(this.productImageBox);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.stockLevelBox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.saleCostBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.productNameBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(698, 325);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(4, 299);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(85, 299);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // productsListView
            // 
            this.productsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.productsListView.FullRowSelect = true;
            this.productsListView.HideSelection = false;
            this.productsListView.Location = new System.Drawing.Point(4, 3);
            this.productsListView.MultiSelect = false;
            this.productsListView.Name = "productsListView";
            this.productsListView.Size = new System.Drawing.Size(157, 294);
            this.productsListView.TabIndex = 0;
            this.productsListView.UseCompatibleStateImageBehavior = false;
            this.productsListView.View = System.Windows.Forms.View.Details;
            this.productsListView.SelectedIndexChanged += new System.EventHandler(this.productsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // barcodeInputBox
            // 
            this.barcodeInputBox.Location = new System.Drawing.Point(92, 90);
            this.barcodeInputBox.Name = "barcodeInputBox";
            this.barcodeInputBox.Size = new System.Drawing.Size(242, 20);
            this.barcodeInputBox.TabIndex = 10;
            this.barcodeInputBox.TextChanged += new System.EventHandler(this.barcodeInputBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Barcode:";
            // 
            // replaceImageButton
            // 
            this.replaceImageButton.Location = new System.Drawing.Point(446, 172);
            this.replaceImageButton.Name = "replaceImageButton";
            this.replaceImageButton.Size = new System.Drawing.Size(75, 23);
            this.replaceImageButton.TabIndex = 8;
            this.replaceImageButton.Text = "Replace";
            this.replaceImageButton.UseVisualStyleBackColor = true;
            this.replaceImageButton.Click += new System.EventHandler(this.replaceImageButton_Click);
            // 
            // productImageBox
            // 
            this.productImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.productImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productImageBox.Location = new System.Drawing.Point(393, 38);
            this.productImageBox.Name = "productImageBox";
            this.productImageBox.Size = new System.Drawing.Size(128, 128);
            this.productImageBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Image:";
            // 
            // stockLevelBox
            // 
            this.stockLevelBox.Location = new System.Drawing.Point(92, 64);
            this.stockLevelBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.stockLevelBox.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.stockLevelBox.Name = "stockLevelBox";
            this.stockLevelBox.Size = new System.Drawing.Size(120, 20);
            this.stockLevelBox.TabIndex = 5;
            this.stockLevelBox.ValueChanged += new System.EventHandler(this.stockLevelBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stock Level:";
            // 
            // saleCostBox
            // 
            this.saleCostBox.DecimalPlaces = 2;
            this.saleCostBox.Location = new System.Drawing.Point(92, 35);
            this.saleCostBox.Name = "saleCostBox";
            this.saleCostBox.Size = new System.Drawing.Size(120, 20);
            this.saleCostBox.TabIndex = 3;
            this.saleCostBox.ValueChanged += new System.EventHandler(this.saleCostBox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sale Cost:";
            // 
            // productNameBox
            // 
            this.productNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productNameBox.Location = new System.Drawing.Point(92, 9);
            this.productNameBox.Name = "productNameBox";
            this.productNameBox.Size = new System.Drawing.Size(429, 20);
            this.productNameBox.TabIndex = 1;
            this.productNameBox.TextChanged += new System.EventHandler(this.productNameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(624, 332);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "Image Files|*.*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Group:";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(92, 112);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(242, 21);
            this.groupComboBox.TabIndex = 12;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            this.groupComboBox.TextChanged += new System.EventHandler(this.groupComboBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(5, 332);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SetupProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 360);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Products";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockLevelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleCostBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListView productsListView;
        private System.Windows.Forms.TextBox productNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown saleCostBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown stockLevelBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button replaceImageButton;
        private System.Windows.Forms.Panel productImageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox barcodeInputBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelButton;
    }
}