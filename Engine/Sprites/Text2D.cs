using SimplG_2D.Core;
using SimplG_2D.Sprites;
using SimplG_2D.Utils;
using System.Drawing;

namespace SimplG_2D.Sprites
{
    /// <summary>
    /// Text2D Class, responsible for rendering text in the game
    /// </summary>
    public class Text2D
    {
        /// <summary>
        /// Position of the Text Object 
        /// </summary>
        public Vec2 Position { get; set; }
        /// <summary>
        /// Size of the Text Object 
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Content of the Text Object 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Color of the Text Object
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Font that the Text Object gonna use (type it in string format)
        /// </summary>
        public string FontString { get; set; }
        /// <summary>
        /// Create a new instance of the Text2D Object
        /// </summary>
        /// <param name="Position">Position of the Text Object </param>
        /// <param name="Size">Size of the Text Object </param>
        /// <param name="Color">Color of the Text Object </param>
        /// <param name="FontString">Font that the Text Object gonna use (type it in string format)</param>
        public Text2D(Vec2 Position, int Size, Color Color, string FontString)
        {
            this.Position = Position;
            this.Size = Size;
            this.Color = Color;
            this.FontString = FontString;
            SimplG.RegisterText(this);
        }
        /// <summary>
        /// Remove the Text2D Object from the RenderStack List
        /// </summary>
        public void Destroy()
        {
            SimplG.UnRegisterText(this);
        }

    }
}
