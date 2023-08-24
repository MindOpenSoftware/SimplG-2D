using System;
using System.Collections.Generic;
using SimplG_2D.Utils;
using SimplG_2D.Core;
using System.Drawing;

namespace SimplG_2D.Sprites
{
    /// <summary>
    /// Line2D Class, responsible for the rendering lines to the Game
    /// </summary>
    public class Line2D
    {
        /// <summary>
        /// Set the Color of the Line
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Set the Line Thickness
        /// </summary>
        public int Thickness { get; set; }
        /// <summary>
        /// Set the Start Position of the Line, from where it gonna start
        /// </summary>
        public Vec2 StartPosition { get; set; }
        /// <summary>
        /// Set the End Position of the Line, from where it gonna end
        /// </summary>
        public Vec2 EndPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartPosition">Set the Start Position of the Line, from where it gonna start</param>
        /// <param name="EndPosition">Set the End Position of the Line, from where it gonna end</param>
        /// <param name="Color">Set the Color of the Line</param>
        public Line2D(Vec2 StartPosition, Vec2 EndPosition, Color Color)
        {
            this.StartPosition = StartPosition;
            this.Color = Color;
            this.EndPosition = EndPosition;

            SimplG.RegisterLine(this);
        }
        /// <summary>
        /// Remove the Line2D Objects from the RenderStack List
        /// </summary>
        public void Destroy()
        {
            SimplG.UnRegisterLine(this);
        }

    }
}
