using System;
using System.Collections.Generic;
using SimplG_2D.Core;

namespace SimplG_2D.Utils
{
    // This class is only available on SimplG 2D V1.3 and Higher V1.0, 1.1, 1.2 are not supported
    /// <summary>
    /// Levels Class, responsible for handling maps and levels inside the game
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Levels List, it contain Levels as string array
        /// </summary>
        public static List<string[,]> Levels = new List<string[,]>();
        /// <summary>
        /// Current Level Index, Indicate the current Level Index, this can be useful if we have multiple Levels
        /// </summary>
        public static int CurrentLevelIndex = 0;
        /// <summary>
        /// Add the specified Level to Levels List
        /// </summary>
        /// <param name="Level">the specified string array Level</param>
        public static void NewLevel(string[,] Level)
        {
            Levels.Add(Level);
        }
        /// <summary>
        /// Return the current Level index value
        /// </summary>
        /// <returns></returns>
        public static string[,] GetCurrentLevel()
        {
            return Levels[CurrentLevelIndex];
        }
        /// <summary>
        /// Get the Tiles from the string array and convert them to Vectors
        /// </summary>
        /// <param name="Tilename">the Tilename from the array string</param>
        /// <param name="Xoffset">the X Offeset between each Tiles</param>
        /// <param name="Yoffset">the Y Offeset between each Tiles</param>
        /// <returns></returns>
        public static List<Vec2> GetTiles(string Tilename, int Xoffset, int Yoffset)
        {
            List<Vec2> v = new List<Vec2>();

            for (int i = 0; i < GetCurrentLevel().GetLength(1); i++)
            {
                for (int j = 0; j < GetCurrentLevel().GetLength(0); j++)
                {
                    if (GetCurrentLevel()[j, i] == Tilename)
                    {
                        v.Add(new Vec2(i * Xoffset, j * Yoffset));
                    }
                }
            }
            return v;
        }


    }
}
