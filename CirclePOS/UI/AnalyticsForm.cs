using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CirclePOS.UI
{
    public partial class AnalyticsForm : Form
    {
        public AnalyticsForm()
        {
            InitializeComponent();
        }
        void updateProductSales()
        {
            salesByProductList.BeginUpdate();
            salesByProductList.Items.Clear();
            foreach (Model.Product p in Program.theDatabase.allProducts)
            {
                Model.Sale[] z = Program.theDatabase.salesContainingProductSince(p.ID, dateTimePicker.Value);

                Decimal totalSold = 0;
                Decimal totalGifted = 0;
                int saleCount=0;
                int giftCount=0;
                foreach (Model.Sale s in z)
                    for(int i=0; i<s.productIDs.Length; i++)
                        if (s.productIDs[i] == p.ID)
                        {
                            if (s.madeFree)
                            {
                                giftCount++;
                                totalGifted += s.productCosts[i];
                            }
                            else
                            {
                                saleCount++;
                                totalSold += s.productCosts[i];
                            }

                        }

                ListViewItem i2 = new ListViewItem(p.name);
                i2.SubItems.Add(saleCount.ToString());
                i2.SubItems.Add(totalSold.ToString("c"));
                i2.SubItems.Add(giftCount.ToString());
                i2.SubItems.Add(totalGifted.ToString("c"));
                salesByProductList.Items.Add(i2);
            }
            salesByProductList.EndUpdate();
        }
        void updateTotals()
        {
            int numSales = Program.theDatabase.itemsSoldSince(dateTimePicker.Value);
            Decimal grossTotal = Program.theDatabase.grossSalesSince(dateTimePicker.Value);
            int numGifted = Program.theDatabase.itemsGiftedSince(dateTimePicker.Value);
            Decimal grossGifted = Program.theDatabase.grossGiftedSince(dateTimePicker.Value);

            grossIncomeLabel.Text = grossTotal.ToString("c");
            grossGiftedLabel.Text = grossGifted.ToString("c");
            totalSoldLabel.Text = numSales.ToString();
            totalGiftedLabel.Text = numGifted.ToString();

            updateProductSales();

            grossOverTimePanel.Refresh();
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updateTotals();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grossIncomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            updateTotals();
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            for (int i = 0; i < grossOverTimePanel.Width; i+= 20)
                g.DrawLine(Pens.DimGray, i, 0, i, grossOverTimePanel.Height);

            for (int i = 0; i < grossOverTimePanel.Height; i += 20)
                g.DrawLine(Pens.DimGray, 0, i, grossOverTimePanel.Width, i);

            List<Decimal> moneyIn = new List<Decimal>();
            List<Decimal> moneyGifted = new List<decimal>();
            
            for (DateTime i = dateTimePicker.Value; i < DateTime.Now; i = i.AddHours(1))
            {
                Decimal m = 0.00m;
                Decimal gm = 0.00m;
                foreach (Model.Sale s in Program.theDatabase.salesBetween(i, i + new TimeSpan(1, 0, 0)))
                    foreach (Decimal d in s.productCosts)
                        if (s.madeFree)
                            gm += d;
                        else
                            m += d;
                moneyIn.Add(m);
                moneyGifted.Add(gm);
            }
            if (moneyIn.Count > 0)
            {
                while (moneyIn.Count > 0 && moneyIn[0] == 0.00m && moneyGifted[0] == 0.00m)
                {
                    moneyIn.RemoveAt(0);
                    moneyGifted.RemoveAt(0);
                }
                while (moneyIn.Count > 0 && moneyIn[moneyIn.Count - 1] == 0.00m && moneyGifted[moneyGifted.Count - 1] == 0.00m)
                {
                    moneyIn.RemoveAt(moneyIn.Count - 1);
                    moneyGifted.RemoveAt(moneyGifted.Count - 1);
                }

                Decimal highest = 0.00m;

                for (int i = 0; i < moneyIn.Count; i++)
                {
                    if (moneyIn[i] > highest)
                        highest = moneyIn[i];
                    if (moneyGifted[i] > highest)
                        highest = moneyGifted[i];

                }

                for (int i = 0; i < moneyIn.Count - 1; i++)
                {
                    float f = i / (float)(moneyIn.Count-1);
                    float f2 = (i + 1) / (float)(moneyIn.Count-1);

                    g.DrawLine(Pens.Green, f * grossOverTimePanel.Width, (1.0f - ((float)moneyIn[i] / (float)highest)) * grossOverTimePanel.Height, f2 * grossOverTimePanel.Width, (1.0f - ((float)moneyIn[i + 1] / (float)highest)) * grossOverTimePanel.Height);
                    g.DrawLine(Pens.Red, f * grossOverTimePanel.Width, (1.0f - ((float)moneyGifted[i] / (float)highest)) * grossOverTimePanel.Height, f2 * grossOverTimePanel.Width, (1.0f - ((float)moneyGifted[i + 1] / (float)highest)) * grossOverTimePanel.Height);

                }
            }
        }
    }
}
