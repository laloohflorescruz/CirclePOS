namespace CirclePOS.UI
{
    partial class SetupPasscodesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupPasscodesForm));
            this.requireCodeToSellBox = new System.Windows.Forms.CheckBox();
            this.changeSalesCodeButton = new System.Windows.Forms.Button();
            this.requireCodeForAdminBox = new System.Windows.Forms.CheckBox();
            this.changeAdminCodeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.requireCodeToGiftBox = new System.Windows.Forms.CheckBox();
            this.changeGiftCodeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requireCodeToSellBox
            // 
            this.requireCodeToSellBox.AutoSize = true;
            this.requireCodeToSellBox.Location = new System.Drawing.Point(12, 17);
            this.requireCodeToSellBox.Name = "requireCodeToSellBox";
            this.requireCodeToSellBox.Size = new System.Drawing.Size(195, 17);
            this.requireCodeToSellBox.TabIndex = 0;
            this.requireCodeToSellBox.Text = "Require Passcode to Operate Sales";
            this.requireCodeToSellBox.UseVisualStyleBackColor = true;
            this.requireCodeToSellBox.CheckedChanged += new System.EventHandler(this.requireCodeToSellBox_CheckedChanged);
            // 
            // changeSalesCodeButton
            // 
            this.changeSalesCodeButton.Location = new System.Drawing.Point(261, 12);
            this.changeSalesCodeButton.Name = "changeSalesCodeButton";
            this.changeSalesCodeButton.Size = new System.Drawing.Size(101, 23);
            this.changeSalesCodeButton.TabIndex = 1;
            this.changeSalesCodeButton.Text = "Change Code";
            this.changeSalesCodeButton.UseVisualStyleBackColor = true;
            this.changeSalesCodeButton.Click += new System.EventHandler(this.changeSalesCodeButton_Click);
            // 
            // requireCodeForAdminBox
            // 
            this.requireCodeForAdminBox.AutoSize = true;
            this.requireCodeForAdminBox.Location = new System.Drawing.Point(12, 41);
            this.requireCodeForAdminBox.Name = "requireCodeForAdminBox";
            this.requireCodeForAdminBox.Size = new System.Drawing.Size(238, 17);
            this.requireCodeForAdminBox.TabIndex = 2;
            this.requireCodeForAdminBox.Text = "Require Passcode to Change Admin Settings";
            this.requireCodeForAdminBox.UseVisualStyleBackColor = true;
            this.requireCodeForAdminBox.CheckedChanged += new System.EventHandler(this.requireCodeForAdminBox_CheckedChanged);
            // 
            // changeAdminCodeButton
            // 
            this.changeAdminCodeButton.Location = new System.Drawing.Point(261, 38);
            this.changeAdminCodeButton.Name = "changeAdminCodeButton";
            this.changeAdminCodeButton.Size = new System.Drawing.Size(101, 23);
            this.changeAdminCodeButton.TabIndex = 3;
            this.changeAdminCodeButton.Text = "Change Code";
            this.changeAdminCodeButton.UseVisualStyleBackColor = true;
            this.changeAdminCodeButton.Click += new System.EventHandler(this.changeAdminCodeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(287, 121);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 121);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // requireCodeToGiftBox
            // 
            this.requireCodeToGiftBox.AutoSize = true;
            this.requireCodeToGiftBox.Location = new System.Drawing.Point(12, 64);
            this.requireCodeToGiftBox.Name = "requireCodeToGiftBox";
            this.requireCodeToGiftBox.Size = new System.Drawing.Size(176, 17);
            this.requireCodeToGiftBox.TabIndex = 6;
            this.requireCodeToGiftBox.Text = "Require Passcode for Gift Sales";
            this.requireCodeToGiftBox.UseVisualStyleBackColor = true;
            this.requireCodeToGiftBox.CheckedChanged += new System.EventHandler(this.requireCodeToGiftBox_CheckedChanged);
            // 
            // changeGiftCodeButton
            // 
            this.changeGiftCodeButton.Location = new System.Drawing.Point(261, 64);
            this.changeGiftCodeButton.Name = "changeGiftCodeButton";
            this.changeGiftCodeButton.Size = new System.Drawing.Size(101, 23);
            this.changeGiftCodeButton.TabIndex = 7;
            this.changeGiftCodeButton.Text = "Change Code";
            this.changeGiftCodeButton.UseVisualStyleBackColor = true;
            this.changeGiftCodeButton.Click += new System.EventHandler(this.changeGiftCodeButton_Click);
            // 
            // SetupPasscodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 149);
            this.Controls.Add(this.changeGiftCodeButton);
            this.Controls.Add(this.requireCodeToGiftBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.changeAdminCodeButton);
            this.Controls.Add(this.requireCodeForAdminBox);
            this.Controls.Add(this.changeSalesCodeButton);
            this.Controls.Add(this.requireCodeToSellBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupPasscodesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passcodes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox requireCodeToSellBox;
        private System.Windows.Forms.Button changeSalesCodeButton;
        private System.Windows.Forms.CheckBox requireCodeForAdminBox;
        private System.Windows.Forms.Button changeAdminCodeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox requireCodeToGiftBox;
        private System.Windows.Forms.Button changeGiftCodeButton;
    }
}