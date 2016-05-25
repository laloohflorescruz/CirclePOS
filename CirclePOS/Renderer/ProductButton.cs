using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace CirclePOS.Renderer
{
    class ProductButton :  IDisposable
    {
        public delegate void ProductButtonClick(Model.Product p);
        public event ProductButtonClick onClick;
        public Guid productID;
        public int x, y;
        ImageTexture back;
        public ProductButton(Guid productID, int x, int y, System.Drawing.Bitmap background)
        {
            this.x = x;
            this.y = y;
            this.productID = productID;
            back = new ImageTexture(background);
        }
        bool amHovering = false;
        public void tick(int mouseX, int mouseY, bool mouseDown)
        {
            if (!visible)
                return;
            brightness = brightness * 0.9f;

            bool wasHovering = amHovering;
            amHovering = false;
            if (mouseX >= x && mouseX < x + 128)
                if (mouseY >= y && mouseY < y + 128)
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
        public void Dispose()
        {

            back.Dispose();
        }
        public bool visible = true;
        float brightness = 0.25f;
        public float multBrightness = 1.0f;
        public void drawBorder()
        {
            if (!visible)
                return;
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);

            GL.Begin(PrimitiveType.LineLoop);
            if(Program.theDatabase.getProduct(productID).stock <= 0)
                GL.Color4(1.0f,0.0f,0.0f, multBrightness);
            else
                GL.Color4(1.0f, 1.0f, 1.0f, multBrightness);
            
            GL.Vertex2(x, y);
            GL.Vertex2(x + 128, y);
            GL.Vertex2(x + 128, y + 128);
            GL.Vertex2(x, y + 128);
            GL.End();

            GL.Disable(EnableCap.Blend);

        }
        static Dictionary<string, StringTexture> textures = new Dictionary<string, StringTexture>();


        void drawString(string s)
        {
            if (!textures.ContainsKey(s))
                textures[s] = GLMethods.generateString(s, 14, System.Drawing.Color.Azure, 128);
            textures[s].draw();

        }
        public bool checkClicked(int x, int y)
        {
            if (x >= this.x && y >= this.y)
                if (x < this.x + 128 && y < this.y + 128)
                {
                    if (Program.theClientSetup.playInterfaceSounds)
                    {
                        System.Media.SoundPlayer p = new System.Media.SoundPlayer(Properties.Resources.MouseOver);
                        p.Play();
                    }
                    if (onClick != null)
                        onClick(Program.theDatabase.getProduct(productID));
                    return true;
                }
            return false;
        }
        public void drawContent()
        {
            if (!visible)
                return;

            string stock = Program.theDatabase.getProduct(productID).stock.ToString() + " in stock";
            string cost = Program.theDatabase.getProduct(productID).cost.ToString("c");

            if (Program.theDatabase.getProduct(productID).stock <= 0)
                GL.Color4(1.0f, 0.3f,0.3f, 1.0f * multBrightness);
            else
                GL.Color4(1.0f - (brightness * 0.75f), 1.0f - (brightness * 0.75f), 1.0f, 1.0f * multBrightness);

            GL.PushMatrix();
            GL.Translate(x, y + 106, 0.0f);
            drawString(cost);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(x, y + 86, 0.0f);
            drawString(stock);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(x, y, 0.0f);


            if (Program.theDatabase.getProduct(productID).stock <= 0)
                GL.Color4(1.0f, 0.0f, 0.0f, 1.0f * multBrightness);
            else
            GL.Color4(1.0f,1.0f,1.0f, 0.5f * multBrightness);
            GL.PushMatrix();
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);

            GL.Scale(128, 128, 1);
            Model.Product z = Program.theDatabase.getProduct(productID);
            if (z.texture == null)
                back.draw();
            else
                z.texture.draw();
            GL.PopMatrix();

            if (Program.theDatabase.getProduct(productID).stock <= 0)
                GL.Color4(1.0f, 0.3f, 0.3f, 1.0f * multBrightness);
            else
                GL.Color4(1.0f - (brightness * 0.75f), 1.0f - (brightness * 0.75f), 1.0f, 1.0f * multBrightness);
            
            drawString(Program.theDatabase.getProduct(productID).name);


            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);

        }

    }
}
