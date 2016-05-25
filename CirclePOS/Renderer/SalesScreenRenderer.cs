using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace CirclePOS.Renderer
{
    class SalesScreenRenderer : Renderer, IDisposable
    {

        StringTexture title;


        bool inTransition = true;
        float transition = 0.0f;
        bool outTransition = false;


        List<Button> cancelButtons = new List<Button>();
        List<Button> theButtons = new List<Button>();
        List<ProductButton> productButtons = new List<ProductButton>();

        Button setupButton;
        Button lockButton;
        Button completeSaleButton;
        Button makeFreeButton;
        public void handleClick(int x, int y)
        {
            foreach (Button b in theButtons)
            {
                if (b.checkClicked(x, y))
                    return;
            }
            foreach (Button b in cancelButtons)
                if (b.checkClicked(x, y))
                    return;
            foreach (ProductButton b in productButtons)
                b.checkClicked(x, y);
        }
        ImageTexture background;
        public SalesScreenRenderer()
        {
            background = new ImageTexture(Properties.Resources.background);
            title = GLMethods.generateString("Sales", 80, System.Drawing.Color.White);

            foreach (Model.Product p in Program.theDatabase.allProducts)
                p.loadImage();

            setupButton = new Button("Admin Setup", 30, System.Drawing.Color.White, System.Drawing.Color.White, 10, 650);
            setupButton.onClick += setupClicked;
            theButtons.Add(setupButton);
            lockButton = new Button("Lock", 30, System.Drawing.Color.White, System.Drawing.Color.White, 280, 650);
            lockButton.onClick += lockClicked;
            theButtons.Add(lockButton);
            completeSaleButton = new Button("Finish Sale", 30, System.Drawing.Color.White, System.Drawing.Color.White, 400, 650);
            completeSaleButton.onClick += completeSaleClicked;
            theButtons.Add(completeSaleButton);
            makeFreeButton = new Button("Make Free", 30, System.Drawing.Color.White, System.Drawing.Color.White, 400, 600);
            makeFreeButton.onClick += makeFreeClicked;
            theButtons.Add(makeFreeButton);

            foreach (Model.Product z in Program.theDatabase.allProducts)
            {
                if (!z.deleted)
                {
                    ProductButton p = new ProductButton(z.ID, 0, 0, Properties.Resources.UnknownItem);
                    p.onClick += productButtonClicked;
                    productButtons.Add(p);
                }
            }
            updateItems();

        }
        public void Dispose()
        {
            title.Dispose();
            background.Dispose();
            foreach (Button b in theButtons)
                b.Dispose();
            foreach (ProductButton z in productButtons)
                z.Dispose();
        }
        List<StringTexture> items = new List<StringTexture>();
        void updateItems()
        {
            if (Program.theDatabase.currentSale.productIDs == null)
                return;
            foreach (StringTexture t in items)
                t.Dispose();
            items.Clear();

            for (int i = 0; i < Program.theDatabase.currentSale.productIDs.Length; i++)
            {
                Model.Product p = Program.theDatabase.getProduct(Program.theDatabase.currentSale.productIDs[i]);
                string s = p.cost.ToString("c");
                s = s + " - " + p.name;

                items.Add(GLMethods.generateString(s, 16, System.Drawing.Color.White));
            }

            foreach (Button b in cancelButtons)
                b.Dispose();
            cancelButtons.Clear();

            for (int i = 0; i < Program.theDatabase.currentSale.productIDs.Length; i++)
            {
                Model.Product p = Program.theDatabase.getProduct(Program.theDatabase.currentSale.productIDs[i]);
                cancelButtons.Add(new Button("x",16, System.Drawing.Color.Red, System.Drawing.Color.Red, 0,0));
                cancelButtons[i].onClick2 += cancelClicked;
            }
            cancelButtons.Add(new Button("X", 16, System.Drawing.Color.Red, System.Drawing.Color.Red, 0, 0));
            cancelButtons[cancelButtons.Count - 1].onClick2 += cancelClicked;

            Program.theDatabase.saveToDisk();
        }
        void cancelClicked(Button sender)
        {
            for (int i = 0; i < cancelButtons.Count; i++)
                if (cancelButtons[i] == sender)
                {
                    if (i == cancelButtons.Count - 1)
                        Program.theDatabase.currentSale.removeAllProducts();
                    else
                        Program.theDatabase.currentSale.removeProductIndex(i);
                    
                    updateItems();
                }
        }
        void productButtonClicked(Model.Product z)
        {
            if (Program.theDatabase.currentSale.productIDs == null)
                Program.theDatabase.currentSale.addProduct(z);
            else
                if (Program.theDatabase.currentSale.productIDs.Length < 15)
                    Program.theDatabase.currentSale.addProduct(z);
            
            updateItems();
        }
        void completeSaleClicked()
        {
            calculateTotal();
            UI.CashForm f = new UI.CashForm(Program.theDatabase.currentSale.totalAmount);
            f.ShowDialog();
            if (f.cancel)
                return;

            System.Media.SoundPlayer p = new System.Media.SoundPlayer(Properties.Resources.CashRegister);
            p.Play();

            Program.theDatabase.currentSale.madeFree = false;
            Program.theDatabase.lastSaleChange = f.change;
            completeSale();
        }
        void calculateTotal()
        {
            Program.theDatabase.currentSale.totalAmount = 0;
            if (!Program.theDatabase.currentSale.madeFree)
                foreach (Decimal d in Program.theDatabase.currentSale.productCosts)
                    Program.theDatabase.currentSale.totalAmount += d;
        }
        void completeSale()
        {
            foreach (Guid i in Program.theDatabase.currentSale.productIDs)
                Program.theDatabase.getProduct(i).stock--;

            calculateTotal();

            Program.theDatabase.currentSale.timeCompleted = DateTime.Now;
            Program.theDatabase.currentSale.saleID = Guid.NewGuid();
            Program.theDatabase.addSale(Program.theDatabase.currentSale);
            Program.theDatabase.saveToDisk();

            foreach (StringTexture t in items)
                t.Dispose();
            items.Clear();

            easingDirection = EasingDirection.right;
            outTransition = true;
            transition = 0.0f;
            destination = new SoldScreenRenderer();
        }
        void makeFreeClicked()
        {
            UI.GiftForm f = new UI.GiftForm();
            f.ShowDialog();
            if (!f.success)
                return;

            Program.theDatabase.lastSaleChange = 0.0m;

            Program.theDatabase.currentSale.madeFree = true;
            completeSale();
        }
        Renderer destination;
        void lockClicked()
        {
            if ((!inTransition && !outTransition) || transition > 0.9f)
            {
                inTransition = false;
                outTransition = true;
                transition = 0.0f;
                easingDirection = EasingDirection.left;
                destination = new LockScreenRenderer();
            }
        }
        void setupClicked()
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

                inTransition = false;
                outTransition = true;
                transition = 0.0f;
                easingDirection = EasingDirection.up;
                destination = new SetupScreenRenderer();
            }
        }
        public void handleScroll(int yDelta)
        {
            scrollingMomentum += yDelta/50.0f;
        }
        float scrollingMomentum = 0.0f;
        float scrollingPos = 0;
        public EasingDirection easingDirection;


        string pastKeys = "";
        public void handleKey(System.Windows.Forms.Keys k)
        {
            string z = k.ToString();
            if (z.StartsWith("NumPad"))
                z = z.Substring("NumPad".Length);
            pastKeys = pastKeys + z;
            if (pastKeys.Length > 100)
                pastKeys = pastKeys.Substring(1);

            foreach (Model.Product p in Program.theDatabase.allProducts)
            {
                if (p.barcode != null && pastKeys.EndsWith(p.barcode))
                {
                    Program.theDatabase.currentSale.addProduct(p);
                    updateItems();

                }

            }

        }

        Dictionary<string, StringTexture> groupTextures = new Dictionary<string, StringTexture>();
        Dictionary<string, int> groupLefts = new Dictionary<string, int>();
        Dictionary<string, int> groupTops = new Dictionary<string, int>();
        public void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight)
        {
            int x = 20;
            int y = 140 + 80 + (int)scrollingPos;
            for (int g = 0; g < Program.theDatabase.getAllGroups().Length; g++)
            {
                
                string groupName = Program.theDatabase.getAllGroups()[g];
                if (groupName != "")
                {
                    if (!groupTextures.ContainsKey(groupName))
                        groupTextures[groupName] = GLMethods.generateString(groupName, 40, System.Drawing.Color.White);
                    groupLefts[groupName] = x + 40;
                    groupTops[groupName] = y - 80;
                }
                
                for (int i = 0; i < productButtons.Count; i++)
                {
                    if(Program.theDatabase.getProduct(productButtons[i].productID).group == groupName){
                        if (y >= (formHeight - 90) || y < 0)
                            productButtons[i].visible = false;
                        else
                        {
                            productButtons[i].multBrightness = 1.0f;
                            if (y >= (formHeight - 90) - 256)
                            {
                                productButtons[i].multBrightness = 1.0f - ((y - ((formHeight - 90) - 256)) / 256.0f);
                            }
                            if (y <= 128)
                            {
                                productButtons[i].multBrightness = y / 128.0f;
                            }
                            productButtons[i].visible = true;

                        }

                        productButtons[i].x = x;
                        productButtons[i].y = y;
                        x += 128 + 5;
                        if (x >= formWidth - 373)
                        {
                            x = 20;
                            y += 140;

                        }
                    }
                }
                x = 20;
                y += 140 + 80;
            }

            scrollingPos -= scrollingMomentum;
            scrollingMomentum *= 0.95f;


            if (scrollingPos < -y - 128)
            {
                scrollingMomentum = 0;
                scrollingPos = -y - 128;
            }
            if (scrollingPos >= 0)
            {

                scrollingMomentum = 0;
                scrollingPos = 0;
            }


            completeSaleButton.x = formWidth - 220;
            completeSaleButton.y = formHeight - 60;
            makeFreeButton.x = formWidth - 220;
            makeFreeButton.y = formHeight - 120;
            setupButton.y = formHeight - 60;
            lockButton.y = formHeight - 60;
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -1.0f);
            GL.ClearColor(0.1f, 0.1f, 0.1f, 0.1f);

            if (inTransition)
            {
                if(easingDirection == EasingDirection.up)
                    GL.Translate(0.0f, (transition - 1.0f) * formHeight * 1.2f, 0.0f);
                if (easingDirection == EasingDirection.left)
                    GL.Translate((1.0f - transition) * formWidth * 1.2f, 0.0f, 0.0f);
                if (easingDirection == EasingDirection.right)
                    GL.Translate(-(1.0f - transition) * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);

                if (transition >= 0.999f)
                {
                    inTransition = false;
                }
            }
            if (outTransition)
            {
                if (easingDirection == EasingDirection.up)
                    GL.Translate(0.0f, -transition * formHeight * 1.2f, 0.0f);
                if (easingDirection == EasingDirection.left)
                    GL.Translate(transition * formWidth * 1.2f, 0.0f, 0.0f);
                if (easingDirection == EasingDirection.right)
                    GL.Translate(-transition * formWidth * 1.2f, 0.0f, 0.0f);
                transition = ((transition * 0.92f) + 0.08f);

                if (transition >= 0.9f)
                {
                    inTransition = false;
                    Program.currentRenderer = destination;
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

            foreach (string s in groupTextures.Keys)
            {
                GL.PushMatrix();

                float m= 1.0f;
                if (groupTops[s]>= (formHeight - 90) - 256)
                    m = 1.0f - ((groupTops[s] - ((formHeight - 90) - 256)) / 256.0f);
                if (groupTops[s] <= 128)
                    m = groupTops[s] / 128.0f;
                GL.Color4(1.0f, 1.0f, 1.0f, 0.75f * m);
                GL.Translate(groupLefts[s], groupTops[s], 0.0f);
                groupTextures[s].draw();

                GL.PopMatrix();

            }

            GL.Color4(1.0f, 1.0f, 1.0f, 0.75f);
            foreach (ProductButton p in productButtons)
            {
                p.tick(mouseX, mouseY, mouseDown);
                p.drawBorder();
                p.drawContent();
            }
            foreach (Button b in theButtons)
            {
                b.tick(mouseX, mouseY, mouseDown);
                b.drawBorder();
                b.drawText();
            }

            for (int i = 0; i < cancelButtons.Count; i++)
            {
                cancelButtons[i].x = formWidth - 265;
                cancelButtons[i].y = 5 + (i * 24);
                if (i == cancelButtons.Count - 1)
                {
                    cancelButtons[i].y += 24;
                    cancelButtons[i].x -= 12;
                }
                cancelButtons[i].tick(mouseX, mouseY, mouseDown);
                cancelButtons[i].drawBorder();
                cancelButtons[i].drawText();

            }

            if(Program.theDatabase.currentSale.productCosts.Length != items.Count)
                updateItems();

            GL.PushMatrix();
            GL.Translate(formWidth - 250, 5, 0);
            GL.Color4(1.0f, 1.0f, 1.0f, 0.75f);
            Decimal total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].draw();
                GL.Translate(0, 24, 0);
                total += Program.theDatabase.currentSale.productCosts[i];
            }

            GL.Color4(1.0f, 1.0f, 1.0f, 0.75f);
            GL.Begin(PrimitiveType.Lines);

            GL.Vertex2(0, 16);
            GL.Vertex2(128, 16);

            GL.End();

            GL.Translate(0, 25, 0);

            if (lastTotal != total)
            {
                if (totalDue != null)
                    totalDue.Dispose();
                totalDue = null;

                string s = "";
                System.Drawing.Color c;
                c = System.Drawing.Color.Red;
                s = "Amount Due: " + total.ToString("c");

                totalDue = GLMethods.generateString(s, 16, c);

                lastTotal = total;
            }

            totalDue.draw();

            GL.PopMatrix();
        }
        Decimal lastTotal = (decimal)-1.0;
        StringTexture totalDue = null;
    }
}
