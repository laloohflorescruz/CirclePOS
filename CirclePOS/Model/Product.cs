using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CirclePOS.Model
{
    class Product
    {
        public Guid ID;
        public string name;
        public Decimal cost;
        public int stock;
        public string barcode;
        public bool deleted = false;
        public string group = "";

        [Newtonsoft.Json.JsonIgnore]
        public Bitmap image;

        [Newtonsoft.Json.JsonIgnore]
        public Renderer.ImageTexture texture = null;

        public string imagePath
        {
            get
            {
                string savePath = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS"), "ProductImages");
                savePath = System.IO.Path.Combine(savePath, name + ".png");

                return savePath;
            }
        }
        public void loadImage()
        {
            if (texture != null)
                return;
            if (System.IO.File.Exists(imagePath))
                this.texture = new Renderer.ImageTexture(new Bitmap(imagePath));
        }

        public void setImage(string path)
        {
            System.Drawing.Bitmap b = null;
            try
            {
                b = new System.Drawing.Bitmap(path);
            }
            catch
            {
                return;
            }

            Bitmap v = new Bitmap(128, 128);

            Graphics g = Graphics.FromImage(v);
            g.Clear(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(b, 0, 0, v.Width, v.Height);
            b = v;
            g.Dispose();


            string savePath = System.IO.Path.Combine( System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS"), "ProductImages");
            if (!System.IO.Directory.Exists(savePath))
                System.IO.Directory.CreateDirectory(savePath);
            v.Save(imagePath);

            this.image = b;
            this.texture = new Renderer.ImageTexture(b);
        }
    }
}
