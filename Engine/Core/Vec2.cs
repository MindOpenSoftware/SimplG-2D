using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplG_2D.Core
{
    /// <summary>
    /// Vector2 Class, handling positions and scales
    /// </summary>
    public class Vec2
    {
        /// <summary>
        /// set the X axis
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// set the Y axis
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Create a new instance of the Vector2 Class
        /// </summary>
        /// <param name="X">X axis value</param>
        /// <param name="Y">Y axis value</param>
        public Vec2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        /// <summary>
        /// Set the X and Y value to Zero
        /// </summary>
        /// <returns>Return a new Vec2 class with null values (Zero)</returns>
        public static Vec2 Zero()
        {
            return new Vec2(0, 0);
        }
    }
}
