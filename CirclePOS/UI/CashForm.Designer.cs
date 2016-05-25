namespace CirclePOS.UI
{
    partial class CashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashForm));
            this.amountDueLabel = new System.Windows.Forms.Label();
            this.hundredDollarButton = new System.Windows.Forms.Button();
            this.fiftyDollarButton = new System.Windows.Forms.Button();
            this.changeDueLabel = new System.Windows.Forms.Label();
            this.twentyDollarButton = new System.Windows.Forms.Button();
            this.tenDollarButton = new System.Windows.Forms.Button();
            this.fiveDollarButton = new System.Windows.Forms.Button();
            this.twoDollarButton = new System.Windows.Forms.Button();
            this.oneDollarButton = new System.Windows.Forms.Button();
            this.fiftyCentsButton = new System.Windows.Forms.Button();
            this.twentyCentsButton = new System.Windows.Forms.Button();
            this.tenCentsButton = new System.Windows.Forms.Button();
            this.fiveCentsButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exactChangeButton = new System.Windows.Forms.Button();
            this.completeButton = new System.Windows.Forms.Button();
            this.cashProvidedLabel = new System.Windows.Forms.Label();
            this.cashProvidedBox = new System.Windows.Forms.ListBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // amountDueLabel
            // 
            this.amountDueLabel.AutoSize = true;
            this.amountDueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDueLabel.Location = new System.Drawing.Point(260, 12);
            this.amountDueLabel.Name = "amountDueLabel";
            this.amountDueLabel.Size = new System.Drawing.Size(246, 42);
            this.amountDueLabel.TabIndex = 0;
            this.amountDueLabel.Text = "Amount Due:";
            // 
            // hundredDollarButton
            // 
            this.hundredDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.hundredDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hundredDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hundredDollarButton.Location = new System.Drawing.Point(10, 12);
            this.hundredDollarButton.Name = "hundredDollarButton";
            this.hundredDollarButton.Size = new System.Drawing.Size(119, 50);
            this.hundredDollarButton.TabIndex = 1;
            this.hundredDollarButton.Text = "$100";
            this.hundredDollarButton.UseVisualStyleBackColor = false;
            this.hundredDollarButton.Click += new System.EventHandler(this.hundredDollarButton_Click);
            // 
            // fiftyDollarButton
            // 
            this.fiftyDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.fiftyDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiftyDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fiftyDollarButton.Location = new System.Drawing.Point(10, 68);
            this.fiftyDollarButton.Name = "fiftyDollarButton";
            this.fiftyDollarButton.Size = new System.Drawing.Size(119, 50);
            this.fiftyDollarButton.TabIndex = 2;
            this.fiftyDollarButton.Text = "$50";
            this.fiftyDollarButton.UseVisualStyleBackColor = false;
            this.fiftyDollarButton.Click += new System.EventHandler(this.fiftyDollarButton_Click);
            // 
            // changeDueLabel
            // 
            this.changeDueLabel.AutoSize = true;
            this.changeDueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeDueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.changeDueLabel.Location = new System.Drawing.Point(260, 54);
            this.changeDueLabel.Name = "changeDueLabel";
            this.changeDueLabel.Size = new System.Drawing.Size(250, 42);
            this.changeDueLabel.TabIndex = 3;
            this.changeDueLabel.Text = "Change Due:";
            // 
            // twentyDollarButton
            // 
            this.twentyDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.twentyDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twentyDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.twentyDollarButton.Location = new System.Drawing.Point(10, 124);
            this.twentyDollarButton.Name = "twentyDollarButton";
            this.twentyDollarButton.Size = new System.Drawing.Size(119, 50);
            this.twentyDollarButton.TabIndex = 4;
            this.twentyDollarButton.Text = "$20";
            this.twentyDollarButton.UseVisualStyleBackColor = false;
            this.twentyDollarButton.Click += new System.EventHandler(this.twentyDollarButton_Click);
            // 
            // tenDollarButton
            // 
            this.tenDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.tenDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tenDollarButton.Location = new System.Drawing.Point(10, 180);
            this.tenDollarButton.Name = "tenDollarButton";
            this.tenDollarButton.Size = new System.Drawing.Size(119, 50);
            this.tenDollarButton.TabIndex = 5;
            this.tenDollarButton.Text = "$10";
            this.tenDollarButton.UseVisualStyleBackColor = false;
            this.tenDollarButton.Click += new System.EventHandler(this.tenDollarButton_Click);
            // 
            // fiveDollarButton
            // 
            this.fiveDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.fiveDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fiveDollarButton.Location = new System.Drawing.Point(10, 236);
            this.fiveDollarButton.Name = "fiveDollarButton";
            this.fiveDollarButton.Size = new System.Drawing.Size(119, 50);
            this.fiveDollarButton.TabIndex = 6;
            this.fiveDollarButton.Text = "$5";
            this.fiveDollarButton.UseVisualStyleBackColor = false;
            this.fiveDollarButton.Click += new System.EventHandler(this.fiveDollarButton_Click);
            // 
            // twoDollarButton
            // 
            this.twoDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.twoDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.twoDollarButton.Location = new System.Drawing.Point(135, 12);
            this.twoDollarButton.Name = "twoDollarButton";
            this.twoDollarButton.Size = new System.Drawing.Size(119, 50);
            this.twoDollarButton.TabIndex = 7;
            this.twoDollarButton.Text = "$2";
            this.twoDollarButton.UseVisualStyleBackColor = false;
            this.twoDollarButton.Click += new System.EventHandler(this.twoDollarButton_Click);
            // 
            // oneDollarButton
            // 
            this.oneDollarButton.BackColor = System.Drawing.SystemColors.Control;
            this.oneDollarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneDollarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneDollarButton.Location = new System.Drawing.Point(135, 68);
            this.oneDollarButton.Name = "oneDollarButton";
            this.oneDollarButton.Size = new System.Drawing.Size(119, 50);
            this.oneDollarButton.TabIndex = 8;
            this.oneDollarButton.Text = "$1";
            this.oneDollarButton.UseVisualStyleBackColor = false;
            this.oneDollarButton.Click += new System.EventHandler(this.oneDollarButton_Click);
            // 
            // fiftyCentsButton
            // 
            this.fiftyCentsButton.BackColor = System.Drawing.SystemColors.Control;
            this.fiftyCentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiftyCentsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fiftyCentsButton.Location = new System.Drawing.Point(135, 124);
            this.fiftyCentsButton.Name = "fiftyCentsButton";
            this.fiftyCentsButton.Size = new System.Drawing.Size(119, 50);
            this.fiftyCentsButton.TabIndex = 9;
            this.fiftyCentsButton.Text = "50c";
            this.fiftyCentsButton.UseVisualStyleBackColor = false;
            this.fiftyCentsButton.Click += new System.EventHandler(this.fiftyCentsButton_Click);
            // 
            // twentyCentsButton
            // 
            this.twentyCentsButton.BackColor = System.Drawing.SystemColors.Control;
            this.twentyCentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twentyCentsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.twentyCentsButton.Location = new System.Drawing.Point(135, 180);
            this.twentyCentsButton.Name = "twentyCentsButton";
            this.twentyCentsButton.Size = new System.Drawing.Size(119, 50);
            this.twentyCentsButton.TabIndex = 10;
            this.twentyCentsButton.Text = "20c";
            this.twentyCentsButton.UseVisualStyleBackColor = false;
            this.twentyCentsButton.Click += new System.EventHandler(this.twentyCentsButton_Click);
            // 
            // tenCentsButton
            // 
            this.tenCentsButton.BackColor = System.Drawing.SystemColors.Control;
            this.tenCentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenCentsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tenCentsButton.Location = new System.Drawing.Point(135, 236);
            this.tenCentsButton.Name = "tenCentsButton";
            this.tenCentsButton.Size = new System.Drawing.Size(119, 50);
            this.tenCentsButton.TabIndex = 11;
            this.tenCentsButton.Text = "10c";
            this.tenCentsButton.UseVisualStyleBackColor = false;
            this.tenCentsButton.Click += new System.EventHandler(this.tenCentsButton_Click);
            // 
            // fiveCentsButton
            // 
            this.fiveCentsButton.BackColor = System.Drawing.SystemColors.Control;
            this.fiveCentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveCentsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fiveCentsButton.Location = new System.Drawing.Point(135, 292);
            this.fiveCentsButton.Name = "fiveCentsButton";
            this.fiveCentsButton.Size = new System.Drawing.Size(119, 50);
            this.fiveCentsButton.TabIndex = 12;
            this.fiveCentsButton.Text = "5c";
            this.fiveCentsButton.UseVisualStyleBackColor = false;
            this.fiveCentsButton.Click += new System.EventHandler(this.fiveCentsButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(12, 345);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(193, 50);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exactChangeButton
            // 
            this.exactChangeButton.BackColor = System.Drawing.SystemColors.Control;
            this.exactChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exactChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exactChangeButton.Location = new System.Drawing.Point(331, 345);
            this.exactChangeButton.Name = "exactChangeButton";
            this.exactChangeButton.Size = new System.Drawing.Size(193, 50);
            this.exactChangeButton.TabIndex = 14;
            this.exactChangeButton.Text = "Exact Change";
            this.exactChangeButton.UseVisualStyleBackColor = false;
            this.exactChangeButton.Click += new System.EventHandler(this.exactChangeButton_Click);
            // 
            // completeButton
            // 
            this.completeButton.BackColor = System.Drawing.SystemColors.Control;
            this.completeButton.Enabled = false;
            this.completeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.completeButton.Location = new System.Drawing.Point(530, 345);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(193, 50);
            this.completeButton.TabIndex = 15;
            this.completeButton.Text = "Okay";
            this.completeButton.UseVisualStyleBackColor = false;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // cashProvidedLabel
            // 
            this.cashProvidedLabel.AutoSize = true;
            this.cashProvidedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashProvidedLabel.Location = new System.Drawing.Point(264, 102);
            this.cashProvidedLabel.Name = "cashProvidedLabel";
            this.cashProvidedLabel.Size = new System.Drawing.Size(114, 16);
            this.cashProvidedLabel.TabIndex = 16;
            this.cashProvidedLabel.Text = "Cash Provided:";
            // 
            // cashProvidedBox
            // 
            this.cashProvidedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashProvidedBox.FormattingEnabled = true;
            this.cashProvidedBox.IntegralHeight = false;
            this.cashProvidedBox.ItemHeight = 18;
            this.cashProvidedBox.Location = new System.Drawing.Point(260, 121);
            this.cashProvidedBox.Name = "cashProvidedBox";
            this.cashProvidedBox.Size = new System.Drawing.Size(461, 162);
            this.cashProvidedBox.TabIndex = 17;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.Control;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearButton.Location = new System.Drawing.Point(530, 289);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(193, 50);
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // CashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(735, 402);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cashProvidedBox);
            this.Controls.Add(this.cashProvidedLabel);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.exactChangeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.fiveCentsButton);
            this.Controls.Add(this.tenCentsButton);
            this.Controls.Add(this.twentyCentsButton);
            this.Controls.Add(this.fiftyCentsButton);
            this.Controls.Add(this.oneDollarButton);
            this.Controls.Add(this.twoDollarButton);
            this.Controls.Add(this.fiveDollarButton);
            this.Controls.Add(this.tenDollarButton);
            this.Controls.Add(this.twentyDollarButton);
            this.Controls.Add(this.changeDueLabel);
            this.Controls.Add(this.fiftyDollarButton);
            this.Controls.Add(this.hundredDollarButton);
            this.Controls.Add(this.amountDueLabel);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashForm";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountDueLabel;
        private System.Windows.Forms.Button hundredDollarButton;
        private System.Windows.Forms.Button fiftyDollarButton;
        private System.Windows.Forms.Label changeDueLabel;
        private System.Windows.Forms.Button twentyDollarButton;
        private System.Windows.Forms.Button tenDollarButton;
        private System.Windows.Forms.Button fiveDollarButton;
        private System.Windows.Forms.Button twoDollarButton;
        private System.Windows.Forms.Button oneDollarButton;
        private System.Windows.Forms.Button fiftyCentsButton;
        private System.Windows.Forms.Button twentyCentsButton;
        private System.Windows.Forms.Button tenCentsButton;
        private System.Windows.Forms.Button fiveCentsButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exactChangeButton;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Label cashProvidedLabel;
        private System.Windows.Forms.ListBox cashProvidedBox;
        private System.Windows.Forms.Button clearButton;
    }
}