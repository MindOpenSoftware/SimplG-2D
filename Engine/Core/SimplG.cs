using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using SimplG_2D.Utils;
using SimplG_2D.Sprites;
using System.Runtime.InteropServices;
using System.Windows;
using System.Runtime.Remoting.Messaging;

namespace SimplG_2D.Core
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    /*
     Fixed some memory leaks, and added support of Mouse Input 2023/07/03 : Version 1.3
    -- NEW Version 1.4 2023/07/30
    ---- Ported to NET FRAMEWORK 4.8
    ---- New Debugging Console (With Built-in commands)
    ---- Added Ready Functions to simplfy game making task for absolute beginners
     */ 
    /// <summary>
    /// The Engine Class, this is the Game core that create the window and handle the graphics
    /// </summary>
    public abstract class SimplG
    {
        internal string Title = "New Game";
        /// <summary>
        /// Get the Size of the Window
        /// </summary>

        [DllImport("Kernel32.dll")]

        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll")]

        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        internal static Vec2 WindowSize = new Vec2(512, 512);
        internal Canvas Window = null;
        public bool LeftClick { get; set; } = false;
        public bool RightClick { get; set; } = false;
        public bool MiddleClick { get; set; } = false;
        internal static Thread GLTd = null;
        internal static List<Sprite2D> SpriteRenderStack { get; } = new List<Sprite2D>();
        internal static List<Shape2D> ShapeRenderStack { get; } = new List<Shape2D>();
        internal static List<Text2D> TextRenderStack { get; } = new List<Text2D>();
        internal static List<Line2D> LineRenderStack { get; } = new List<Line2D>();
        /// <summary>
        /// Set the Type of a Shape2D Object
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Circle Shape Type
            /// </summary>
            Circle,
            /// <summary>
            /// Rectangle Shape Type
            /// </summary>
            Rectangle
        }
        /// <summary>
        /// Set the background color of the Game window
        /// </summary>
        public Color BackgroundColor { get; set; } = Color.Black;
        /// <summary>
        /// Indicate if the Window type is a Sizable Window or a Fixed Window
        /// </summary>
        public bool Sizable { get; set; } = false;
        /// <summary>
        /// Create a new instance of the Game core and intialize a new Window
        /// </summary>
        /// <param name="Title">Set the title string</param>
        /// <param name="Resolution">Set the size of the window</param>
        /// <param name="Sizable">Set if the Window type is a Sizable Window or a Fixed Window</param>
        public SimplG(string Title, Vec2 Resolution, bool Sizable)
        {
            this.Title = Title;
            WindowSize = Resolution;
            this.Sizable = Sizable;
            Window = new Canvas();
            Window.Size = new System.Drawing.Size((int)WindowSize.X + 15, (int)WindowSize.Y + 40);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.FormClosing += Window_FormClosing;
            Window.ResizeBegin += Window_ResizeBegin;
            Window.ResizeEnd += Window_ResizeEnd;
            Window.MouseUp += Window_MouseUp;
            Window.MouseDown += Window_MouseDown;

            UserControl ctrl = new UserControl();
            

            if (this.Sizable)
            {
                Window.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }
            else
            {
                Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }

            GLTd = new Thread(GLoop);
            GLTd.SetApartmentState(ApartmentState.STA);
            GLTd.Start();


            System.Windows.Forms.Application.Run(Window);

            
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { LeftClick = true; }
            if (e.Button == MouseButtons.Right) { RightClick = true; }
            if (e.Button == MouseButtons.Middle) { MiddleClick = true; }
        }

        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { LeftClick = false; }
            if (e.Button == MouseButtons.Right) { RightClick = false; }
            if (e.Button == MouseButtons.Middle) { MiddleClick = false; }
        }
        public void HideConsole(bool value)
        {
            if (value)
            {
                IntPtr hWnd = GetConsoleWindow();
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 0);
                }
            }
            else
            {
                IntPtr hWnd = GetConsoleWindow();
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 1);
                }
            }
        }
        private void Window_ResizeEnd(object sender, EventArgs e)
        {
            
            GLTd.Resume();
        }

        private void Window_ResizeBegin(object sender, EventArgs e)
        {
           
            GLTd.Suspend();
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GLTd.Abort();
                Log.Info("See you later, SimplG 2D is Closing !...");
            }
            catch
            {
                Log.Error("Sorry an error occurced while Closing");
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.Clear(BackgroundColor);

                foreach(Sprite2D Sp in SpriteRenderStack)
                {
                    g.DrawImageUnscaledAndClipped(Sp.Image, new Rectangle((int)Sp.Position.X, (int)Sp.Position.Y, (int)Sp.Size.X, (int)Sp.Size.Y));
                }
                foreach (Text2D Te in TextRenderStack)
                {
                    g.DrawString(Te.Text, new Font(Te.FontString, Te.Size), new SolidBrush(Te.Color), new PointF(
                        Te.Position.X, Te.Position.Y));
                }
                foreach (Shape2D S in ShapeRenderStack)
                {
                    if (S.Type == Type.Circle)
                    {
                        g.FillEllipse(new SolidBrush(S.Color), new RectangleF(S.Position.X, S.Position.Y, S.Size.X, S.Size.Y));
                    }
                    if (S.Type == Type.Rectangle)
                    {
                        g.FillRectangle(new SolidBrush(S.Color), new RectangleF(S.Position.X, S.Position.Y, S.Size.X, S.Size.Y));
                    }
                }
                foreach (Line2D L in LineRenderStack)
                {
                    g.DrawLine(new Pen(new SolidBrush(L.Color), L.Thickness), new PointF(L.StartPosition.X, L.StartPosition.Y), new PointF(
                        L.EndPosition.X, L.EndPosition.Y));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        internal static void RegisterSprite(Sprite2D s)
        {
            SpriteRenderStack.Add(s);
        }
        internal static void UnRegisterSprite(Sprite2D s)
        {
            SpriteRenderStack.Remove(s);
        }
        internal static void RegisterText(Text2D t)
        {
            TextRenderStack.Add(t);
        }
        internal static void UnRegisterText(Text2D t)
        {
            TextRenderStack.Remove(t);
        }
        internal static void RegisterShape(Shape2D b)
        {
            ShapeRenderStack.Add(b);
        }
        internal static void UnRegisterShape(Shape2D b)
        {
            ShapeRenderStack.Remove(b);
        }
        internal static void RegisterLine(Line2D l)
        {
            LineRenderStack.Add(l);
        }
        internal static void UnRegisterLine(Line2D l)
        {
            LineRenderStack.Remove(l);
        }

        [Obsolete]
        private void GLoop()
        {
            OnLoad();
            
            while (GLTd.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(10);
                }
                catch (Exception ex)
                {
                    Log.Warn(ex.Message);
                }
            }
            
        }

        
        /// <summary>
        /// Before the Game Loads
        /// </summary>
        public abstract void OnLoad();
        /// <summary>
        /// Drawing Events
        /// </summary>
        public abstract void OnDraw();
        /// <summary>
        /// Events (After the Game Loads)
        /// </summary>
        public abstract void OnUpdate();
    }
}
