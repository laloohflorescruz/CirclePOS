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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        Renderer.CustomerScreenRenderer renderer;
        private void CustomerForm_Shown(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            renderer = new Renderer.CustomerScreenRenderer();
            if (Program.theClientSetup.customerScreenNumber < Screen.AllScreens.Length && Program.theClientSetup.customerScreenNumber >= 0)
                this.Bounds = Screen.AllScreens[Program.theClientSetup.customerScreenNumber].Bounds;

            
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


        private void drawTimer_Tick(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            setMatrixMode();

            renderer.draw(0, 0, false, this.ClientRectangle.Width, this.ClientRectangle.Height);

            glControl1.SwapBuffers();
        }
    }
}
