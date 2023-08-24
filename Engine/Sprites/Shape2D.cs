using System;
using SimplG_2D.Core;
using SimplG_2D.Utils;
using System.Drawing;

namespace SimplG_2D.Sprites
{
    /// <summary>
    /// Shape2D Class, responsible of the rendering of Shape Object to the Game
    /// </summary>
    public class Shape2D
    {
        /// <summary>
        /// Position of the Shape Object
        /// </summary>
        public Vec2 Position { get; set; }
        /// <summary>
        /// Size of the Shape Object
        /// </summary>
        public Vec2 Size { get; set; }
        /// <summary>
        /// Image of the Shape Object
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// the Sprite Tag
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Set the Direction of the Shape Object, this can be useful if you use Bullets or you are beginner in coding and you used ReadyFunctions Class, Note that direction must be only words that indicate directions like left, up...
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// Set the Type of the Shape Object, it can be a Circle or a Rectangle
        /// </summary>
        public SimplG.Type Type { get; set; }
        /// <summary>
        /// Create a new instance of the Shape2D Object
        /// </summary>
        /// <param name="Position">Position of the Shape Object</param>
        /// <param name="Size">Size of the Shape Object</param>
        /// <param name="Tag">the Shape Tag</param>
        public Shape2D(Vec2 Position, Vec2 Size, Color Color, string Tag)
        {
            this.Position = Position;
            this.Size = Size;
            this.Color = Color;
            this.Tag = Tag;

            SimplG.RegisterShape(this);
        }
        /// <summary>
        /// Shoot a Bullet from the current Object
        /// </summary>
        /// <param name="Bullet">The Bullet Object, it can be a Shape2D or Sprite2D Object</param>
        /// <param name="Speed">The Speed of the Bullet Object</param>
        /// <param name="Direction">The Direction of the Bullet</param>
        public void ShootBullet(Sprite2D Bullet, float Speed, string Direction)
        {
            if (Direction == "left")
            {
                Bullet.Position.X -= Speed;
            }
            if (Direction == "right")
            {
                Bullet.Position.X += Speed;
            }
            if (Direction == "up")
            {
                Bullet.Position.Y -= Speed;
            }
            if (Direction == "down")
            {
                Bullet.Position.Y += Speed;
            }
        }
        /// <summary>
        /// Shoot a Bullet from the current Object
        /// </summary>
        /// <param name="Bullet">The Bullet Object, it can be a Shape2D or Sprite2D Object</param>
        /// <param name="Speed">The Speed of the Bullet Object</param>
        /// <param name="Direction">The Direction of the Bullet</param>
        public void ShootBullet(Shape2D Bullet, float Speed, string Direction)
        {
            if (Direction == "left")
            {
                Bullet.Position.X -= Speed;
            }
            if (Direction == "right")
            {
                Bullet.Position.X += Speed;
            }
            if (Direction == "up")
            {
                Bullet.Position.Y -= Speed;
            }
            if (Direction == "down")
            {
                Bullet.Position.Y += Speed;
            }
        }
         /// <summary>
        /// Return the current Collided Shapee2D Object
        /// </summary>
        /// <param name="b">The Shape2D Object</param>
        /// <returns></returns>
        public Shape2D IsCollided(Shape2D b)
        {
            if (Position.X < b.Position.X + b.Size.X && Position.X + Size.X > b.Position.X &&
                Position.Y < b.Position.Y + b.Size.Y && Position.Y + Size.Y > b.Position.Y)
            {
                return b;
            }
            return null;
        }
        /// <summary>
        /// Return the current Collided Shape2D Object
        /// </summary>
        /// <param name="Tag">The Collided Shape2D Tag</param>
        /// <returns></returns>
        public Shape2D IsCollided(string Tag)
        {
            foreach (Shape2D b in SimplG.ShapeRenderStack)
            {
                if (b.Tag == Tag)
                {
                    if (Position.X < b.Position.X + b.Size.X && Position.X + Size.X > b.Position.X &&
                        Position.Y < b.Position.Y + b.Size.Y && Position.Y + Size.Y > b.Position.Y)
                    {
                        return b;
                    }
                }
            }
            return null;
        }
        /// 
        /// <summary>
        /// Remove the Shape2D Object from the RenderStack List
        /// </summary>
        public void Destroy()
        {
            SimplG.UnRegisterShape(this);
        }
    }
}

