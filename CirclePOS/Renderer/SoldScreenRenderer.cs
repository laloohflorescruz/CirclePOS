using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class SoldScreenRenderer  : Renderer, IDisposable
    {

        StringTexture title;
        ImageTexture background;
        public void Dispose()
        {
            title.Dispose();
            background.Dispose();
        }

        public SoldScreenRenderer()
        {
            title = GLMethods.generateString("Sold!", 80, System.Drawing.Color.White);
            background = new ImageTexture(Properties.Resources.background3);
        }
        public void handleClick(int x, int y)
        {

        }

        public void handleKey(System.Windows.Forms.Keys k)
        {

        }
        float timer = 0.0f;

        bool inTransition = true;
        float transition = 0.0f;
        bool outTransition = false;
        public void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight)
        {
            GL.ClearColor(0.1f, 0.3f, 0.1f, 0.1f);

            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -1.0f);
            if (inTransition)
            {
                GL.Translate((1.0f - transition) * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);
                GL.ClearColor(0.1f, 0.1f + (transition * 0.2f), 0.1f, 0.1f);

                if (transition >= 0.999f)
                {
                    transition = 0.0f;
                    inTransition = false;
                }
            }
            else if (outTransition)
            {
                GL.Translate(transition * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);
                GL.ClearColor(0.1f, 0.3f - (transition * 0.2f), 0.1f, 0.1f);


                if (transition >= 0.9f)
                {
                    transition = 0.0f;
                    inTransition = false;
                    Program.currentRenderer.Dispose();
                    Program.currentRenderer = new SalesScreenRenderer();
                    ((SalesScreenRenderer)Program.currentRenderer).easingDirection = EasingDirection.right;

                    Program.theDatabase.currentSale = new Model.Sale();
                    Program.theDatabase.saveToDisk();
                }
            }
            else
            {
                timer += 0.1f;
                if (timer >= 1.0f)
                {
                    outTransition = true;
                }

            }

            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.DstColor, BlendingFactorDest.SrcColor);

            GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
            GL.PushMatrix();
            GL.Scale(formWidth, formHeight, 0);
            background.draw();
            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);

            GL.Color4(1.0f, 1.0f, 1.0f, 0.75f);
            title.draw();
        }

        public void handleScroll(int delta)
        {

        }
    }
}
