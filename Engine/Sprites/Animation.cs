using System;
using System.Collections.Generic;
using System.Drawing;


namespace SimplG_2D.Sprites
{
    /// <summary>
    /// Animation Class, it is an extension of Sprite2D Class it is responsible for Animations (SimplG 2D BETA 2 and Higher)
    /// </summary>
    public class Animation
    {
        List<Image> frames = new List<Image>();
        int delay_Count = 0;
        int increment = 0;
        /// <summary>
        /// add a Specified Frame to the frames List
        /// </summary>
        /// <param name="frame">the Frame Image</param>
        public void AddFrame(Image frame)
        {
            frames.Add(frame);
        }
        /// <summary>
        /// Delay between Frames in milliseconds
        /// </summary>
        public int delay {get; set;} = 10;
        /// <summary>
        /// Play the Animation from the frames List
        /// </summary>
        /// <returns></returns>
        public Image PlayOneFrame()
        {
            delay_Count++;
            if (delay_Count % delay == 0)
            {
                increment = (increment == frames.Count) ? 0 : increment + 1;
            }
            return frames[increment - 1];
        }
    }

}

