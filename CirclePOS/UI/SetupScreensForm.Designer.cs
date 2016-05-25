namespace CirclePOS.UI
{
    partial class SetupScreensForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupScreensForm));
            this.label1 = new System.Windows.Forms.Label();
            this.customerScreenEnableBox = new System.Windows.Forms.CheckBox();
            this.mainControlScreenList = new System.Windows.Forms.ComboBox();
            this.customerScreenList = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.playInterfaceSoundsBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.advertisingBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Control Screen:";
            // 
            // customerScreenEnableBox
            // 
            this.customerScreenEnableBox.AutoSize = true;
            this.customerScreenEnableBox.Location = new System.Drawing.Point(12, 38);
            this.customerScreenEnableBox.Name = "customerScreenEnableBox";
            this.customerScreenEnableBox.Size = new System.Drawing.Size(110, 17);
            this.customerScreenEnableBox.TabIndex = 1;
            this.customerScreenEnableBox.Text = "Customer Screen:";
            this.customerScreenEnableBox.UseVisualStyleBackColor = true;
            // 
            // mainControlScreenList
            // 
            this.mainControlScreenList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainControlScreenList.FormattingEnabled = true;
            this.mainControlScreenList.Location = new System.Drawing.Point(125, 8);
            this.mainControlScreenList.Name = "mainControlScreenList";
            this.mainControlScreenList.Size = new System.Drawing.Size(171, 21);
            this.mainControlScreenList.TabIndex = 2;
            // 
            // customerScreenList
            // 
            this.customerScreenList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerScreenList.FormattingEnabled = true;
            this.customerScreenList.Location = new System.Drawing.Point(125, 38);
            this.customerScreenList.Name = "customerScreenList";
            this.customerScreenList.Size = new System.Drawing.Size(171, 21);
            this.customerScreenList.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(222, 250);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(12, 250);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // playInterfaceSoundsBox
            // 
            this.playInterfaceSoundsBox.AutoSize = true;
            this.playInterfaceSoundsBox.Location = new System.Drawing.Point(91, 65);
            this.playInterfaceSoundsBox.Name = "playInterfaceSoundsBox";
            this.playInterfaceSoundsBox.Size = new System.Drawing.Size(130, 17);
            this.playInterfaceSoundsBox.TabIndex = 6;
            this.playInterfaceSoundsBox.Text = "Play Interface Sounds";
            this.playInterfaceSoundsBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Advertising Text:";
            // 
            // advertisingBox
            // 
            this.advertisingBox.Location = new System.Drawing.Point(12, 101);
            this.advertisingBox.Multiline = true;
            this.advertisingBox.Name = "advertisingBox";
            this.advertisingBox.Size = new System.Drawing.Size(285, 143);
            this.advertisingBox.TabIndex = 8;
            // 
            // SetupScreensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 283);
            this.Controls.Add(this.advertisingBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playInterfaceSoundsBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.customerScreenList);
            this.Controls.Add(this.mainControlScreenList);
            this.Controls.Add(this.customerScreenEnableBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupScreensForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Screens";
            this.Load += new System.EventHandler(this.SetupScreensForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox customerScreenEnableBox;
        private System.Windows.Forms.ComboBox mainControlScreenList;
        private System.Windows.Forms.ComboBox customerScreenList;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox playInterfaceSoundsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox advertisingBox;
    }
}