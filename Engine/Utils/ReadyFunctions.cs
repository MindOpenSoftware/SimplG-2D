using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplG_2D.Core;
using SimplG_2D.Sprites;

namespace SimplG_2D.Utils
{
    /// <summary>
    /// Soon
    /// </summary>
    public static class ReadyFunctions
    {
        static InputHandler IH = new InputHandler();
        /// <summary>
        /// Apply Mouvements for a Specified Sprite2D Object
        /// </summary>
        /// <param name="Player">The Player Sprite2D Object</param>
        /// <param name="Speed">The Speed of The Player</param>
        /// <param name="Only4Directions">Specify whether you'll move only 4 directions</param>
        public static void ApplyMouvements(Sprite2D Player, int Speed, bool Only4Directions)
        {
            if (Only4Directions)
            {
                if (IH.Z)
                {
                    Player.Position.Y -= Speed;
                }
                else if (IH.S)
                {
                    Player.Position.Y += Speed;
                }
                else if (IH.D)
                {
                    Player.Position.X -= Speed;
                }
                else if (IH.Q)
                {
                    Player.Position.X += Speed;
                }
            }
            else
            {
                if (IH.Z)
                {
                    Player.Position.Y -= Speed;
                }
                if (IH.S)
                {
                    Player.Position.Y += Speed;
                }
                if (IH.D)
                {
                    Player.Position.X -= Speed;
                }
                if (IH.Q)
                {
                    Player.Position.X += Speed;
                }
            }
        }
        /// <summary>
        /// Apply Mouvements for a Specified Shape2D Object
        /// </summary>
        /// <param name="Player">The Player Shapee2D Object</param>
        /// <param name="Speed">The Speed of The Player</param>
        /// <param name="Only4Directions">Specify whether you'll move only 4 directions</param>
        public static void ApplyMouvements(Shape2D Player, int Speed, bool Only4Directions)
        {
            if (Only4Directions)
            {
                if (IH.Z)
                {
                    Player.Position.Y -= Speed;
                }
                else if (IH.S)
                {
                    Player.Position.Y += Speed;
                }
                else if (IH.D)
                {
                    Player.Position.X -= Speed;
                }
                else if (IH.Q)
                {
                    Player.Position.X += Speed;
                }
            }
            else
            {
                if (IH.Z)
                {
                    Player.Position.Y -= Speed;
                }
                if (IH.S)
                {
                    Player.Position.Y += Speed;
                }
                if (IH.D)
                {
                    Player.Position.X -= Speed;
                }
                if (IH.Q)
                {
                    Player.Position.X += Speed;
                }
            }
        }
        public static void BounceIfOnEdge(Sprite2D Object)
        {
            if (Object.Position.X < 0)
            {
                Object.Position.X = 0;
            }
            if (Object.Position.X + Object.Size.X > SimplG.WindowSize.X)
            {
                Object.Position.X = SimplG.WindowSize.X - Object.Size.X;
            }
            if (Object.Position.Y + Object.Size.Y > SimplG.WindowSize.Y)
            {
                Object.Position.Y = SimplG.WindowSize.Y - Object.Size.Y;
            }
            if (Object.Position.Y < 0)
            {
                Object.Position.Y = 0;
            }
        }
        
    }
}
