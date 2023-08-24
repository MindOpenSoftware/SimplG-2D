using System;
using System.Collections.Generic;
using System.Linq;
using SimplG_2D.Utils;
using SimplG_2D.Core;
using System.Drawing;

namespace SimplG_2D.Sprites
{
    /*
     Update Sprite Class 2023/07/03 Update, Changes : Fixed memory leaks by Creating a method to stop creating multiple instance of image
     class for example if a map have the same sprite the engine will create an image for each block separetly this will cause memory leaks
     we prevented this by creating another constructor of the Sprite2D which will handle only  refrencing the image, so it can be like a
     public that we will reuse it, *sorry for my bad english :)
     */ 
    /// <summary>
    /// Sprite2D Class, responsible of the rendering of Sprite Object to the Game
    /// </summary>
    public class Sprite2D
    {
        /// <summary>
        /// Position of the Sprite Object
        /// </summary>
        public Vec2 Position { get; set; }
        /// <summary>
        /// Size of the Sprite Object
        /// </summary>
        public Vec2 Size { get; set; }
        /// <summary>
        /// Directory of the Image of the Sprite Object
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// the Image of the Sprite Object
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// the Sprite Tag
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Set the Direction of the Sprite Object, this can be useful if you use Bullets or you don't know coding and you used ReadyFunctions Class, Note that direction must be only words that indicate directions like left, up...
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// Check if the Specified Sprite2D is an actual Object or just a Reference to another one
        /// </summary>
        public bool IsReference { get; } = false;
        /// <summary>
        /// Create a new instance of the Sprite2D Object
        /// </summary>
        /// <param name="Position">Position of the Sprite Object</param>
        /// <param name="Size">Size of the Sprite Object</param>
        /// <param name="Directory">Directory of the Image of the Sprite Object</param>
        /// <param name="Tag">the Sprite Tag</param>
        public Sprite2D(Vec2 Position, Vec2 Size, string Directory, string Tag)
        {
            this.Position = Position;
            this.Size = Size;
            this.Tag = Tag;
            this.Directory = Directory;

            Image tmp = System.Drawing.Image.FromFile($"{Directory}");
            Image sprite = tmp;
            Image = sprite;

            SimplG.RegisterSprite(this);
        }
        /// <summary>
        /// Create a new instance of the Sprite2D Class, but this instance is used only to Reference an actual Sprite, so to avoid Memory leaks
        /// </summary>
        /// <param name="Directory">Directory of the Image of the Sprite Object</param>
        public Sprite2D(string Directory)
        {
            this.IsReference = true;
            this.Directory = Directory;

            Image tmp = System.Drawing.Image.FromFile($"{Directory}");
            Image sprite = tmp;
            Image = sprite;

            SimplG.RegisterSprite(this);
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
        /// Remove the Sprite2D Object from the RenderStack List
        /// </summary>
        public void Destroy()
        {
            SimplG.UnRegisterSprite(this);
        }
        /// <summary>
        /// Return the current Collided Sprite2D Object
        /// </summary>
        /// <param name="b">The Sprite2D Object</param>
        /// <returns></returns>
        public Sprite2D IsCollided(Sprite2D b)
        {
            if (Position.X < b.Position.X + b.Size.X && Position.X + Size.X > b.Position.X &&
                Position.Y < b.Position.Y + b.Size.Y && Position.Y + Size.Y > b.Position.Y)
            {
                return b;
            }
            return null;
        }
        /// <summary>
        /// Return the current Collided Sprite2D Object
        /// </summary>
        /// <param name="Tag">The Collided Sprite2D Tag</param>
        /// <returns></returns>
        public Sprite2D IsCollided(string Tag)
        {
            foreach (Sprite2D b in SimplG.SpriteRenderStack)
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
    }
}
