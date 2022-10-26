using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;

namespace Data_Visualization_Tool
{
    public class WindowController
    {
        GameWindow window;
        public WindowController(GameWindow _window)
        {
            window = _window;
            Start();
        }

        void Start()
        {
            
        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(100f, 100f, 100f, 0f);
        }

        void renderF(object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            window.SwapBuffers();
        }
    }
}
