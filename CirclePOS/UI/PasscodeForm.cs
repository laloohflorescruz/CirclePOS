using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class PasscodeForm : Form
    {
        public PasscodeForm()
        {
            InitializeComponent();
        }
        public bool cancel = false;
        public string inputResult = "";
        void draw()
        {

            Bitmap z = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);

            Graphics g = Graphics.FromImage(z);

            int blockHeight = (this.ClientRectangle.Height / 4);
            int blockWidth = (this.ClientRectangle.Width / 3);
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                {
                    Brush b = Brushes.Gray;
                    Point p = this.PointToClient(Cursor.Position);
                    if (p.X >= x * blockWidth && p.X < (x + 1) * blockWidth)
                        if (p.Y >= y * blockHeight && p.Y < (y + 1) * blockHeight)
                            b = Brushes.White;
                    g.FillRectangle(b, new Rectangle(x * blockWidth, y * blockHeight, blockWidth, blockHeight));

                    string number = "";
                    if (y < 3)
                        number = (x + 1 + (y * 3)).ToString();
                    if (y == 3 && x == 1)
                        number = "0";
                    if (y == 3 && x == 0)
                        number = "Exit";
                    if (y == 3 && x == 2)
                        number = "OK";
                    string font = "Lucida Sans Unicode";
                    RectangleF r = new RectangleF(x * blockWidth, y * blockHeight, blockWidth, blockHeight);
                    SizeF bz = g.MeasureString(number, new Font(font, 30));
                    g.DrawString(number, new Font(font, 30), Brushes.Black, r.Left + (r.Width / 2) - (bz.Width / 2), r.Top + (r.Height / 2) - (bz.Height / 2)); 
                }
            for (int x = 0; x <= 3; x++)
                g.DrawLine(new Pen(Color.Black, 3), x * blockWidth, 0, x * blockWidth, this.Height);
            for (int y = 0; y <= 4; y++)
                g.DrawLine(new Pen(Color.Black, 3), 0, y * blockHeight, this.Width, y * blockHeight);

            this.CreateGraphics().DrawImage(z, 0, 0);
        }
        private void PasscodeForm_MouseMove(object sender, MouseEventArgs e)
        {
            draw();
        }

        private void PasscodeForm_Shown(object sender, EventArgs e)
        {
            draw();
        }

        private void PasscodeForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                
                int blockHeight = (this.ClientRectangle.Height / 4);
                int blockWidth = (this.ClientRectangle.Width / 3);


                if (Program.theClientSetup.playInterfaceSounds)
                {
                    System.Media.SoundPlayer p = new System.Media.SoundPlayer(Properties.Resources.Click);
                    p.Play();
                }
                if (e.X < blockWidth && e.Y < blockHeight)
                    inputResult = inputResult + "1";
                if (e.X >= blockWidth && e.X < blockWidth * 2 && e.Y < blockHeight)
                    inputResult = inputResult + "2";
                if (e.X >= blockWidth * 2 && e.Y < blockHeight)
                    inputResult = inputResult + "3";

                if (e.X < blockWidth && e.Y >= blockHeight && e.Y < blockHeight * 2)
                    inputResult = inputResult + "4";
                if (e.X >= blockWidth && e.X < blockWidth * 2 && e.Y >= blockHeight && e.Y < blockHeight * 2)
                    inputResult = inputResult + "5";
                if (e.X >= blockWidth * 2 && e.Y >= blockHeight && e.Y < blockHeight * 2)
                    inputResult = inputResult + "6";

                if (e.X < blockWidth && e.Y >= blockHeight*2 && e.Y < blockHeight* 3)
                    inputResult = inputResult + "7";
                if (e.X >= blockWidth && e.X < blockWidth * 2 && e.Y >= blockHeight *2 && e.Y < blockHeight * 3)
                    inputResult = inputResult + "8";
                if (e.X >= blockWidth * 2 && e.Y >= blockHeight *2&& e.Y < blockHeight * 3)
                    inputResult = inputResult + "9";

                if (e.X >= blockWidth && e.X < blockWidth * 2 && e.Y >= blockHeight * 3)
                    inputResult = inputResult + "0";

                if (e.Y >= blockHeight * 3)
                {
                    if (e.X < blockWidth)
                    {
                        cancel = true;
                        this.Close();
                    }
                    if (e.X >= blockWidth * 2)
                    {
                        cancel = false;
                        this.Close();
                    }


                }

            }
        }

        private void PasscodeForm_Load(object sender, EventArgs e)
        {
            Program.preferredCursor = Cursors.Hand;
        }


        public string codedInputResult = "";

        private void PasscodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.preferredCursor = Cursors.Arrow;
            if (inputResult == "")
                codedInputResult = "";
            else
            {
                System.Security.Cryptography.SHA512Managed m = new System.Security.Cryptography.SHA512Managed();
                codedInputResult = Convert.ToBase64String(m.ComputeHash(Encoding.UTF8.GetBytes(inputResult + Program.theDatabase.salt)));
            }
        }

        private void PasscodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool z = false;
            if (e.KeyCode == Keys.NumPad0)
            {
                inputResult = inputResult + "0";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                inputResult = inputResult + "1";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                inputResult = inputResult + "2";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                inputResult = inputResult + "3";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                inputResult = inputResult + "4";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                inputResult = inputResult + "5";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                inputResult = inputResult + "6";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                inputResult = inputResult + "7";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                inputResult = inputResult + "8";
                z = true;
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                inputResult = inputResult + "9";
                z = true;
            }
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                cancel = false;
                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                cancel = true;
                this.Close();

            }
            if (z)
            {
                if (Program.theClientSetup.playInterfaceSounds)
                {
                    System.Media.SoundPlayer p = new System.Media.SoundPlayer(Properties.Resources.Click);
                    p.Play();
                }

            }
        }
    }
}
