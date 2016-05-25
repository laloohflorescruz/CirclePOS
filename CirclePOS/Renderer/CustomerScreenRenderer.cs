using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace CirclePOS.Renderer
{
    class CustomerScreenRenderer : Renderer
    {
        StringTexture withYouInAMoment;
        StringTexture purchase;
        StringTexture thanks;
        StringTexture available;

        StringTexture[] advertisements = new StringTexture[] { };

        public void Dispose()
        {

            withYouInAMoment.Dispose();
            purchase.Dispose();
            thanks.Dispose();
        }

        public void handleScroll(int yDelta)
        {

        }
        void createTexts()
        {
            withYouInAMoment = GLMethods.generateString(Program.theClientSetup.oneMomentText, 50, System.Drawing.Color.Azure);
            purchase = GLMethods.generateString(Program.theClientSetup.purchaseText, 70, System.Drawing.Color.White);
            thanks = GLMethods.generateString(Program.theClientSetup.thankYou, 80, System.Drawing.Color.White);
            available = GLMethods.generateString(Program.theClientSetup.forSaleText, 80, System.Drawing.Color.White);
        }
        public CustomerScreenRenderer()
        {
            createTexts();
        }
        int adCount;
        void createAdvertisements(int width)
        {
            for (int i = 0; i < advertisements.Length; i++)
                advertisements[i].Dispose();
            string[] z = Program.theDatabase.advertising.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);
            adCount = z.Length;
            advertisements = new StringTexture[z.Length];
            for (int i = 0; i < z.Length; i++)
            {
                advertisements[i] = GLMethods.generateString(z[i], 60, System.Drawing.Color.White, width);

            }
            lastAds = Program.theDatabase.advertising;
        }
        enum ScreenType
        {
            withYouInAMoment,
            purchase,
            thanks
        }

        public void handleKey(System.Windows.Forms.Keys k)
        {

        }
        string lastAds="";
        ScreenType currentScreen = ScreenType.withYouInAMoment;
        ScreenType goalScreen = ScreenType.withYouInAMoment;
        float fading = 0.0f;

        static Dictionary<string, StringTexture> savedText = new Dictionary<string, StringTexture>();
        public void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight)
        {
            if (lastAds != Program.theDatabase.advertising)
                createAdvertisements(formWidth);
            GL.ClearColor(0.1f, 0.1f, 0.1f, 0.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -1.0f);
            GL.Color4(1.0f, 1.0f, 1.0f, 0.5f * fading);

            if (Program.currentRenderer is LockScreenRenderer || Program.currentRenderer is SetupScreenRenderer)
                goalScreen = ScreenType.withYouInAMoment;
            if (Program.currentRenderer is SalesScreenRenderer)
                goalScreen = ScreenType.purchase;
            if (Program.currentRenderer is SoldScreenRenderer)
                goalScreen = ScreenType.thanks;

            if (currentScreen != goalScreen)
            {
                fading -= 0.05f;
                if (fading <= 0.0f)
                {
                    fading = 0.0f;
                    currentScreen = goalScreen;
                }
            }
            if (currentScreen == goalScreen)
            {
                fading += 0.05f;
                if (fading >= 1.0f)
                    fading = 1.0f;
            }

            if (currentScreen == ScreenType.purchase)
            {
                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f * fading);
                purchase.draw();
                GL.PushMatrix();
                GL.Color4(1.0f, 1.0f, 1.0f, 0.5f * fading);
                GL.Translate(formWidth * 0.666f, 0.0f, 0.0f);
                available.draw();
                GL.PopMatrix();
                
                Decimal t=0;
                for (int i = 0; i < Program.theDatabase.currentSale.productNames.Length; i++ )
                {
                    t += Program.theDatabase.currentSale.productCosts[i];
                    string prodName = Program.theDatabase.currentSale.productNames[i];
                    string prodCost = Program.theDatabase.currentSale.productCosts[i].ToString("c");

                    if (!savedText.ContainsKey(prodName))
                        savedText[prodName] = GLMethods.generateString(prodName, 40, System.Drawing.Color.White);
                    if (!savedText.ContainsKey(prodCost))
                        savedText[prodCost] = GLMethods.generateString(prodCost, 40, System.Drawing.Color.White);

                    GL.PushMatrix();
                    GL.Translate(0, (50 * i)+100, 0);
                    GL.Color4(1.0f, 1.0f, 1.0f, 0.75f * fading);
                    savedText[prodName].draw();
                    GL.Translate(formWidth / 3.0f, 0, 0);
                    savedText[prodCost].draw();


                    GL.PopMatrix();

                }

                for (int i = 0; i < Program.theDatabase.allProducts.Length; i++)
                {
                    string prodName = Program.theDatabase.allProducts[i].name;
                    string prodCost = Program.theDatabase.allProducts[i].cost.ToString("c");

                    if (!savedText.ContainsKey(prodName))
                        savedText[prodName] = GLMethods.generateString(prodName, 40, System.Drawing.Color.White);
                    if (!savedText.ContainsKey(prodCost))
                        savedText[prodCost] = GLMethods.generateString(prodCost, 40, System.Drawing.Color.White);

                    GL.PushMatrix();
                    GL.Translate(formWidth / 2.0f, (50 * i) + 100, 0);
                    GL.Color4(1.0f, 1.0f, 1.0f, 0.333f * fading);
                    savedText[prodName].draw();
                    GL.PopMatrix();

                    GL.PushMatrix();
                    GL.Translate(formWidth * 0.9f, (50 * i) + 100, 0);
                    savedText[prodCost].draw();


                    GL.PopMatrix();

                }
                string totalText = "Total";
                string totalCost = t.ToString("c");

                if (!savedText.ContainsKey(totalText))
                    savedText[totalText] = GLMethods.generateString(totalText, 40, System.Drawing.Color.White);
                if (!savedText.ContainsKey(totalCost))
                    savedText[totalCost] = GLMethods.generateString(totalCost, 40, System.Drawing.Color.White);
                GL.PushMatrix();
                GL.Translate(0, (50 * Program.theDatabase.currentSale.productNames.Length) + 200, 0);
                GL.Color4(1.0f, 0.0f, 0.0f, 0.75f * fading);
                savedText[totalText].draw();
                GL.Translate(formWidth/3.0f, 0, 0);
                savedText[totalCost].draw();


                GL.PopMatrix();


            }

            if (currentScreen == ScreenType.withYouInAMoment)
            {

                GL.PushMatrix();
                GL.Translate((formWidth / 2) - (withYouInAMoment.getWidth() / 2), (formHeight / 2) - (withYouInAMoment.getHeight() / 2), 0.0f);
                withYouInAMoment.draw();

                GL.PopMatrix();
            }

            if (currentScreen == ScreenType.thanks)
            {

                GL.Color4(1.0f, 1.0f, 1.0f, 0.75f * fading);
                GL.PushMatrix();
                GL.Translate((formWidth / 2) - (thanks.getWidth() / 2), (formHeight / 2) - (thanks.getHeight() / 2), 0.0f);
                thanks.draw();
                GL.PopMatrix();

                if (Program.theDatabase.lastSaleChange > 0)
                {
                    GL.PushMatrix();
                    string change = "Your Change: " + Program.theDatabase.lastSaleChange.ToString("c");

                    if (!savedText.ContainsKey(change))
                        savedText[change] = GLMethods.generateString(change, 70, System.Drawing.Color.White);
                    GL.Translate((formWidth / 2) - (savedText[change].getWidth() / 2), ((formHeight / 2) - (thanks.getHeight() / 2)) + thanks.getHeight(), 0);
                    GL.Color4(0.5f, 1.0f, 0.5f, 0.85f * fading);
                    savedText[change].draw();
                    GL.PopMatrix();
                }

            }

            adTimer += 0.02f;
            if (adTimer < 1.0f)
                GL.Color4(1.0f, 1.0f, 1.0f, adTimer);
            else if (adTimer < 5.0f)
                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
            else
            {
                if (adTimer >= 6.0f)
                {
                    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
                    adTimer = 0.0f;
                    adNum++;
                    if (adNum >= adCount)
                        adNum = 0;
                }else
                    GL.Color4(1.0f, 1.0f, 1.0f, 6.0f-adTimer);
            }

            if (adCount > 0)
            {
                GL.PushMatrix();
                GL.Translate((formWidth / 2) - (advertisements[adNum].getWidth() / 2), formHeight - thanks.getHeight(), 0.0f);
                advertisements[adNum].draw();

                GL.PopMatrix();
            }
        }

        float adTimer = 0.0f;
        int adNum = 0;
        
        public void handleClick(int x, int y)
        {

        }
    }
}
