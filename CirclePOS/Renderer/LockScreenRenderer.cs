using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace CirclePOS.Renderer
{
    class LockScreenRenderer : Renderer
    {

        StringTexture title;


        bool inTransition = true;
        float transition = 0.0f;
        bool outTransition = false;

        List<Button> theButtons = new List<Button>();
        ImageTexture background;

        Button unlockButton;
        public void handleClick(int x, int y)
        {
            foreach (Button b in theButtons)
                b.checkClicked(x, y);

        }

        public LockScreenRenderer()
        {
            title = GLMethods.generateString("Locked!", 80, System.Drawing.Color.White);

            background = new ImageTexture(Properties.Resources.background2);

            unlockButton = new Button("Unlock", 30, System.Drawing.Color.White, System.Drawing.Color.White, 20, 650);
            unlockButton.onClick += unlockClicked;
            theButtons.Add(unlockButton);
        }
        public void handleScroll(int yDelta)
        {

        }

        public void Dispose()
        {
            title.Dispose();
            unlockButton.Dispose();
        }
        void unlockClicked()
        {

            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                if (Program.theDatabase.salesLockCode != "")
                {
                    UI.PasscodeForm f = new UI.PasscodeForm();
                    f.ShowDialog();
                    if (f.codedInputResult != Program.theDatabase.salesLockCode || f.cancel)
                        return;
                }

                inTransition = false;
                outTransition = true;
                transition = 0.0f;
            }
        }
        public void handleKey(System.Windows.Forms.Keys k)
        {

        }
        public void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight)
        {
            unlockButton.y = formHeight - 90;
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -1.0f);
            GL.ClearColor(0.3f, 0.1f, 0.1f, 0.1f);

            if (inTransition)
            {
                GL.Translate((transition - 1.0f) * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);
                GL.ClearColor(0.1f + (transition * 0.2f), 0.1f, 0.1f, 0.1f);

                if (transition >= 0.999f)
                {
                    inTransition = false;
                }
            }
            if (outTransition)
            {
                GL.Translate(-transition * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);
                GL.ClearColor(0.3f - (transition * 0.2f), 0.1f, 0.1f, 0.1f);


                if (transition >= 0.9f)
                {
                    inTransition = false;
                    Program.currentRenderer = new SalesScreenRenderer();
                    ((SalesScreenRenderer)Program.currentRenderer).easingDirection = EasingDirection.left;
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


            foreach (Button b in theButtons)
            {
                b.tick(mouseX, mouseY, mouseDown);
                b.drawBorder();
                b.drawText();
            }

        }
    }
}
