using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
namespace CirclePOS.Renderer
{
    class StringTexture : IDisposable
    {
        public void Dispose()
        {
            GL.DeleteTexture(texNum);
        }
        public int getTexNum()
        {
            return texNum;
        }
        int texNum;
        int width;
        int height;
        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height;
        }
        public void draw()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texNum);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 0); GL.Vertex2(width, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(width, height);
            GL.TexCoord2(0,1); GL.Vertex2(0,height);


            GL.End();


            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
        }
        public StringTexture(int texNum, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.texNum = texNum;
        }
    }
}
