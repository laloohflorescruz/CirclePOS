using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class SetupScreenRenderer : Renderer
    {
        float phase = 0.0f;
        StringTexture title;
        Button setupPasscodesButton;
        Button setupProductsButton;
        Button viewAnalyticsButton;
        Button salesScreenButton;
        Button setupScreensButton;
        Button editSalesButton;
        List<Button> theButtons = new List<Button>();
        ImageTexture background;
        EasingDirection easingDirection;

        public void handleKey(System.Windows.Forms.Keys k)
        {

        }
        public SetupScreenRenderer()
        {
            background = new ImageTexture(Properties.Resources.background);

            title = GLMethods.generateString("Admin Setup", 80, System.Drawing.Color.Coral);
            setupPasscodesButton = new Button("Setup Passcodes", 30, System.Drawing.Color.Azure, System.Drawing.Color.White, 30, 120);
            setupProductsButton = new Button("Setup Products", 30, System.Drawing.Color.LightSalmon, System.Drawing.Color.White, 30, 180);
            viewAnalyticsButton = new Button("View Analytics", 30, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.White, 30, 240);
            setupScreensButton = new Button("Setup Screens", 30, System.Drawing.Color.LightGreen, System.Drawing.Color.White, 30, 300);
            editSalesButton = new Button("Edit Sales", 30, System.Drawing.Color.White, System.Drawing.Color.White, 380, 120);

            salesScreenButton = new Button("Return to Sales", 30, System.Drawing.Color.White, System.Drawing.Color.White, 20, 650);

            setupPasscodesButton.onClick += editPasscodesClicked;
            setupProductsButton.onClick += editProductsClicked;
            viewAnalyticsButton.onClick += analyticsClicked;
            setupScreensButton.onClick += editScreensClicked;
            editSalesButton.onClick += editSalesClicked;

            theButtons.Add(setupProductsButton);
            theButtons.Add(setupPasscodesButton);
            theButtons.Add(viewAnalyticsButton);
            theButtons.Add(salesScreenButton);
            theButtons.Add(setupScreensButton);
            theButtons.Add(editSalesButton);

            salesScreenButton.onClick += returnToSales;
        }

        void editSalesClicked()
        {
            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                UI.EditSales e = new UI.EditSales();
                e.ShowDialog();
            }
        }

        void analyticsClicked()
        {

            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                UI.AnalyticsForm z = new UI.AnalyticsForm();
                z.ShowDialog();
            }
        }
        void editScreensClicked()
        {

            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                UI.SetupScreensForm z = new UI.SetupScreensForm();
                z.ShowDialog();
            }
        }
        void editProductsClicked()
        {

            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                UI.SetupProductsForm z = new UI.SetupProductsForm();
                z.ShowDialog();
            }
        }
        public void handleScroll(int yDelta)
        {

        }
        void editPasscodesClicked()
        {

            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                if (Program.theDatabase.adminLockCode != "")
                {
                    UI.PasscodeForm f = new UI.PasscodeForm();
                    f.ShowDialog();

                    if (f.cancel || f.codedInputResult != Program.theDatabase.adminLockCode)
                        return;
                }

                UI.SetupPasscodesForm z = new UI.SetupPasscodesForm();
                z.ShowDialog();
            }
        }

        void returnToSales()
        {
            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                transition = 0.0f;
                inTransition = false;
                outTransition = true;
            }
        }

        public void handleClick(int x, int y)
        {
            foreach (Button b in theButtons)
                b.checkClicked(x, y);

        }
        public void Dispose()
        {
            title.Dispose();
            foreach (Button b in theButtons)
                b.Dispose();
            background.Dispose();
        }
        float transition = 0.0f;
        bool inTransition = true;
        bool outTransition = false;
        public void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight)
        {
            salesScreenButton.y = formHeight - 90;
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -1.0f);
            GL.ClearColor(0.1f, 0.1f, 0.3f, 0.1f);

            if (inTransition)
            {
                GL.Translate(0.0f, (1.0f - transition) * formHeight * 1.2f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);

                GL.ClearColor(0.1f, 0.1f, 0.1f + (transition * 0.2f), 0.1f);

                if (transition >= 0.999f)
                {
                    inTransition = false;
                }
            }
            if (outTransition)
            {
                GL.Translate(0.0f, transition * formHeight * 1.2f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);

                GL.ClearColor(0.1f, 0.1f, 0.3f - (transition * 0.2f), 0.1f);

                if (transition >= 0.9f)
                {
                    Dispose();
                    Program.currentRenderer = new SalesScreenRenderer();
                    ((SalesScreenRenderer)Program.currentRenderer).easingDirection = EasingDirection.up;
                    return;
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
            if (phase <= 1.0f)
                GL.Color4(1.0f, 1.0f, 1.0f, phase);
            else
                GL.Color4(1.0f, 1.0f, 1.0f, 0.6f + ((((float)Math.Sin(phase)+1.0f)/2.0f)*0.4f));
            phase += 0.03f;

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
