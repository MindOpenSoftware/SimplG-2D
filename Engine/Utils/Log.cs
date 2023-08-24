using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using SimplG_2D.Core;
using SimplG_2D.Sprites;

namespace SimplG_2D.Utils
{
    /*
     Updated Log class, added another function which send a message with a green color that mean that a specific operation has been done 
     succesfully
     */
    /// <summary>
    /// Log class is an alternative class of Console class, controlling the debug console 
    /// </summary>
    /// }
    /// 
    public class Log
    {
        public static string Response { get; set; }
        #region


        /// <summary>
        /// Print a message in the color of an "Message" to the debugging console,
        /// "Message" color = Color.White
        /// </summary>
        /// <param name="msg">the message string</param>
        public static void Message(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[Msg] : {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;

        }
        /// <summary>
        /// Print a message in the color of an "Info" to the debugging console,
        /// "Info" color = Color.Cyan
        /// </summary>
        /// <param name="msg">the message string</param>
        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Info] : {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Print a message in the color of an "Warning" to the debugging console,
        /// "Warning" color = Color.Yellow
        /// </summary>
        /// <param name="msg">the message string</param>
        public static void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Warning] : {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Print a message in the color of an "Error" to the debugging console,
        /// "Error" color = Color.Red
        /// </summary>
        /// <param name="msg">the message string</param>
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] : {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        ///  Print a message in the color of an "Error" to the debugging console,
        ///  "Succes" color = Color.Red
        /// </summary>
        /// <param name="msg">the message string</param>
        public static void Succes(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Succesfully] : {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Read the input from the debug console input stream 
        /// </summary>
        public static void ReadInput()
        {
            Console.ReadLine();
        }
        #endregion

        public Log()
        {
            Info("SimplG Console v1.4 -- Home");

            Response = Console.ReadLine();
            string prefix = "/";

            if (Response == prefix + "get-sprite-info")
            {
                Succes("Please type the object tag, to get information about it !");
                var getobj_input = Console.ReadLine();
                foreach (var obj in SimplG.SpriteRenderStack)
                {
                    if (getobj_input == obj.Tag)
                    {
                        Info("Found a match !");
                        Message("Sprite tag : " + obj.Tag);
                        Message("Sprite img directory : " + obj.Directory);
                        Message("Sprite Position : " + obj.Position);
                        Message("Sprite Size : " + obj.Size);
                        Message("Is it a reference " + obj.IsReference);
                    }
                    Warn("Task ended !, Press any key to exit to normal output console");
                    Console.ReadKey();
                }
            }
            if (Response == prefix + "start-game")
            {
                
            }
            else
            {
                Error($"Invalid Command [ '{prefix + Response}' ]");
            }
        }
    }
}


