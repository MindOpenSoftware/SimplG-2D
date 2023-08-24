using System;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using System.Linq;
using SimplG_2D.Utils;
using System.Threading;
using SimplG_2D.Sprites;

namespace SimplG_Loader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            { 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"SimplG 2D Game Compiler v1.0 By @invalid403, [ Script is Loaded ]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[WHITE_FLAG] : Please provide a name for your executable file !");
                var ExecutableName = Console.ReadLine();
                var Name = ExecutableName + ".exe";
                CompilerResults results;

                string[] source = args;

                for (int i = 0; i < args.Length; i++)
                {
                    for (int j = 0; j < source.Length; j++)
                    {
                        source[j] = File.ReadAllText(source[j]);
                        results = BuildApp(new[] { source[j] }, Name, new[] {"SimplG 2D.Dll", "System.Core.Dll",
                    "System.Dll", "System.Drawing.Dll"});
                        if (results.Errors.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"[GREEN_FLAG] : Code Compiled Succesfully with Name of ' {Name} '");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            foreach (CompilerError e in results.Errors)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"[RED_FLAG] : {"Failed to compile " + e.ErrorText}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        Console.Write("Press any key to exit !");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"SimplG 2D Game Compiler v1.0 By @invalid403, [ No Script is Loaded ]");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Closing After...");
                Thread.Sleep(1000);
                Console.WriteLine("3");
                Thread.Sleep(1000);
                Console.WriteLine("2");
                Thread.Sleep(1000);
                Console.WriteLine("1");
                Thread.Sleep(1000);
                Console.WriteLine("Closing...");
            }
        }
        private static CompilerResults BuildApp(string[] sources, string output, params string[] references)
        {
            var param = new CompilerParameters(references, output);
            param.GenerateExecutable = true;
            using (var provider = new CSharpCodeProvider())
            {
                return provider.CompileAssemblyFromSource(param, sources);
            }
           
        }
    }
}
