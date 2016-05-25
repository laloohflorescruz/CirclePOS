namespace CirclePOS.UI
{
    partial class PasscodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasscodeForm));
            this.SuspendLayout();
            // 
            // PasscodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 307);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasscodeForm";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Passcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasscodeForm_FormClosing);
            this.Load += new System.EventHandler(this.PasscodeForm_Load);
            this.Shown += new System.EventHandler(this.PasscodeForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasscodeForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PasscodeForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PasscodeForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}