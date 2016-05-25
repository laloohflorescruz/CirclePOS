using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class GLMethods
    {
        public static StringTexture generateString(string s, int size, Color foreColor, int maxWidth = 2048)
        {
            int oversampling = 3;

            Bitmap z = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(z);
            SizeF textSize = g.MeasureString(s, new Font("Arial", size * oversampling),maxWidth * oversampling);
            g.Dispose();
            z.Dispose();

            
            z = new Bitmap((int)textSize.Width, (int)textSize.Height);
            g = Graphics.FromImage(z);
            g.Clear(Color.FromArgb(0,0,0,0));
            g.DrawString(s, new Font("Arial", size * oversampling), new SolidBrush(foreColor), new RectangleF(0, 0, maxWidth * oversampling, maxWidth * oversampling));
            g.Dispose();

            Bitmap v = new Bitmap((int)textSize.Width / oversampling, (int)textSize.Height / oversampling);

            g = Graphics.FromImage(v);
            g.Clear(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            
            g.DrawImage(z, 0, 0, v.Width, v.Height);
            z = v;
            g.Dispose();

            int x = GL.GenTexture();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, x);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear); 
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            System.Drawing.Imaging.BitmapData i = z.LockBits(new Rectangle(0, 0, z.Width, z.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, z.Width, z.Height, 0, PixelFormat.Bgra, PixelType.UnsignedInt8888Reversed, i.Scan0);
            z.UnlockBits(i);

            GL.Disable(EnableCap.Texture2D);

            return new StringTexture(x,z.Width,z.Height);
        }
    }
}
