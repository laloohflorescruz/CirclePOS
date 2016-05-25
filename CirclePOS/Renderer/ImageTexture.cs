using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class ImageTexture: IDisposable
    {
        public void Dispose()
        {
            GL.DeleteTexture(texNum);
        }
        int texNum;
        public ImageTexture(System.Drawing.Bitmap b)
        {
            System.Drawing.Imaging.BitmapData d = b.LockBits(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            texNum = GL.GenTexture();
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texNum);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, b.Width, b.Height, 0, PixelFormat.Bgra, PixelType.UnsignedInt8888Reversed, d.Scan0);
            b.UnlockBits(d);
            GL.Disable(EnableCap.Texture2D);
        }
        public void draw()
        {


            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texNum);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 0); GL.Vertex2(1, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(1, 1);
            GL.TexCoord2(0, 1); GL.Vertex2(0, 1);
            GL.End();


            GL.Disable(EnableCap.Texture2D);
        }
    }
}
