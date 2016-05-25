using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class Button : IDisposable
    {
        StringTexture texture;

        System.Drawing.Color borderColor;
        System.Drawing.Color theColor;
        public int x, y;
        public Button(string text, int size, System.Drawing.Color theColor, System.Drawing.Color borderColor, int x, int y)
        {
            texture = GLMethods.generateString(text, size, theColor);
            this.borderColor = borderColor;
            this.x = x;
            this.y = y;
            this.theColor = theColor;
        }

        public void Dispose()
        {
            this.texture.Dispose();
        }
        bool amHovering = false;

        public delegate void VoidCall();
        public event VoidCall onClick;
        public delegate void ButtonClickedEvent(Button b);
        public event ButtonClickedEvent onClick2;


        public bool checkClicked(int x, int y)
        {
            if(x >= this.x && y >= this.y)
                if (x < this.x + texture.getWidth() && y < this.y + texture.getHeight())
                {
                    if (Program.theClientSetup.playInterfaceSounds)
                    {
                        System.Media.SoundPlayer p = new System.Media.SoundPlayer(Properties.Resources.MouseOver);
                        p.Play();
                    }
                    if (onClick != null)
                        onClick();
                    if (onClick2 != null)
                        onClick2(this);
                    return true;
                }
            return false;
        }
        public void tick(int mouseX, int mouseY, bool mouseDown)
        {
            brightness = brightness*0.9f;

            bool wasHovering = amHovering;
            amHovering = false;
            if (mouseX >= x && mouseX < x + texture.getWidth())
                if (mouseY >= y && mouseY < y + texture.getHeight())
                {
                    brightness = brightness + 0.25f;
                    if (brightness > 1.0f)
                        brightness = 1.0f;
                    if (!amHovering)
                    {
                        if (!wasHovering)
                        {
                        }
                        amHovering = true;
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                        Program.preferredCursor = System.Windows.Forms.Cursors.Hand;
                    }
                }
            if (!amHovering && wasHovering)
            {

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;
                Program.preferredCursor = System.Windows.Forms.Cursors.Arrow;
            }
        }
        float brightness = 0.0f;
        public void drawBorder()
        {

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);

            GL.Begin(PrimitiveType.LineLoop);
            //GL.Color4(borderColor.R, borderColor.G, borderColor.B, (byte)(brightness * 255.0f));
            GL.Color4(1.0f,1.0f,1.0f,1.0f);
            GL.Vertex2(x, y);
            GL.Vertex2(x + texture.getWidth(), y);
            GL.Vertex2(x + texture.getWidth(), y+texture.getHeight());
            GL.Vertex2(x, y+texture.getHeight());
            GL.End();


            GL.Disable(EnableCap.Blend);

        }

        public void drawText()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);

            GL.Color4(1.0f - (brightness * 0.75f), 1.0f - (brightness * 0.75f), 1.0f, 1.0f);
            GL.PushMatrix();
            GL.Translate(x, y,0);
            texture.draw();
            GL.PopMatrix();

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
        }
    }
}
