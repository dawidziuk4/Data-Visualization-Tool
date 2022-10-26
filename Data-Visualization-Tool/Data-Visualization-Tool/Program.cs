using Data_Visualization_Tool;
using Data_Visualization_Tool.Models;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

class Program
{

    public static void Main(string[] args)
    {

        GameWindowSettings gws = GameWindowSettings.Default;
        gws.RenderFrequency = 60.0;
        gws.UpdateFrequency = 60.0;

        NativeWindowSettings nws = NativeWindowSettings.Default;
        nws.IsEventDriven = false;
        nws.API = ContextAPI.OpenGL;
        nws.APIVersion = Version.Parse("4.1");
        nws.AutoLoadBindings = true;
        nws.Size = new Vector2i(1080, 720);
        nws.Title = "3D Data  Visualization Tool";

        GameWindow window = new GameWindow(gws, nws);

        window.Load += delegate
        {
            int program = CreateShader();
            GL.UseProgram(program);

        };

        window.RenderFrame += delegate
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            int vao = CreateVao(out int indexBuffer);

            GL.BindBuffer(BufferTarget.ArrayBuffer, indexBuffer);
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, 3, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.DeleteBuffer(indexBuffer);
            GL.DeleteVertexArray(vao);

            window.SwapBuffers();
        };

        window.Run();

    }

    public static int CreateShader()
    {
        int vShader = GL.CreateShader(ShaderType.VertexShader);
        int fShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(vShader, File.ReadAllText("../../../assets/vertex_shader.glsl"));
        GL.ShaderSource(fShader, File.ReadAllText("../../../assets/fragment_shader.glsl"));
        GL.CompileShader(fShader);
        GL.CompileShader(vShader);
        Console.WriteLine(GL.GetShaderInfoLog(fShader));
        Console.WriteLine(GL.GetShaderInfoLog(vShader));

        int program = GL.CreateProgram();
        GL.AttachShader(program, vShader);
        GL.AttachShader(program, fShader);
        GL.LinkProgram(program);
        GL.DetachShader(program, vShader);
        GL.DetachShader(program, fShader);
        GL.DeleteShader(vShader);
        GL.DeleteShader(fShader);

        Console.WriteLine(GL.GetProgramInfoLog(program));

        return program;
    }

    public static int CreateVao(out int indexBuffer)
    {
        int vertexBuffer = GL.GenBuffer();
        int colorBuffer = GL.GenBuffer();
        indexBuffer = GL.GenBuffer();
        int vao = GL.GenVertexArray();

        GL.BindVertexArray(vao);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
        GL.BufferData(BufferTarget.ArrayBuffer, 9 * sizeof(float), new float[] { -0.5f, -0.5f, 0.0f, 0.5f, -0.5f, 0.0f, 0.0f, 0.5f, 0.0f }, BufferUsageHint.StaticCopy);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(0);

        GL.BindBuffer(BufferTarget.ArrayBuffer, colorBuffer);
        GL.BufferData(BufferTarget.ArrayBuffer, 9 * sizeof(float), new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f }, BufferUsageHint.StaticCopy);
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(1);

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
        GL.BufferData(BufferTarget.ElementArrayBuffer, 3 * sizeof(int), new int[] { 0, 1, 2 }, BufferUsageHint.StaticCopy);
        GL.BindVertexArray(0);

        GL.DeleteBuffer(vertexBuffer);
        GL.DeleteBuffer(colorBuffer);

        return vao;
    }
}