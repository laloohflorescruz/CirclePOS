using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace CirclePOS.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            glControl1.MouseWheel += glControl1_MouseWheelOrDown;
        }

        void setMatrixMode()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl1.Width, glControl1.Height, 0, 0.1f, 100.0f);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            setMatrixMode();
            Point p = glControl1.PointToClient(Cursor.Position);
            Program.currentRenderer.draw(p.X, p.Y, false, this.ClientRectangle.Width, this.ClientRectangle.Height);
            glControl1.SwapBuffers();

            if(this.Focused)    
                glControl1.Cursor = Program.preferredCursor;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

            if (Program.theClientSetup.controlScreenNumber < Screen.AllScreens.Length && Program.theClientSetup.controlScreenNumber >= 0)
            {
                this.Left = Screen.AllScreens[Program.theClientSetup.controlScreenNumber].WorkingArea.Left;
                this.Top = Screen.AllScreens[Program.theClientSetup.controlScreenNumber].WorkingArea.Top;
                this.WindowState = FormWindowState.Maximized;
            }
            glControl1.MakeCurrent();
            Program.currentRenderer = new Renderer.LockScreenRenderer();
            if (Program.theClientSetup.customerScreenNumber < Screen.AllScreens.Length && Program.theClientSetup.customerScreenNumber >= 0)
            {
                CustomerForm f = new CustomerForm();
                f.Show();
            }
        }

        private void glControl1_MouseWheelOrDown(object sender, MouseEventArgs e)
        {
            Point p = glControl1.PointToClient(Cursor.Position);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                Program.currentRenderer.handleClick(p.X, p.Y);
            if (e.Delta != 0)
                Program.currentRenderer.handleScroll(e.Delta);
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            Program.currentRenderer.handleKey(e.KeyCode);
        }
    }
}
