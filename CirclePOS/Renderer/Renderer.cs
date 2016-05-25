using System;
using System.Collections.Generic;
using System.Text;

namespace CirclePOS.Renderer
{
    public enum EasingDirection
    {
        left,
        right,
        up,
        down
    }
    interface Renderer : IDisposable
    {
        void Dispose();
        void draw(int mouseX, int mouseY, bool mouseDown, int formWidth, int formHeight);
        void handleClick(int mouseX, int mouseY);
        void handleScroll(int yDelta);
        void handleKey(System.Windows.Forms.Keys k);
    }
}
