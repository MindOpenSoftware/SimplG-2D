using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplG_2D.Core
{
    /// <summary>
    /// The InputHandler Class, handling the Mouse and Keyboard pressing and release events
    /// </summary>
    public class InputHandler
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool E { get; set; }
        public bool F { get; set; }
        public bool G { get; set; }
        public bool H { get; set; }
        public bool I { get; set; }
        public bool J { get; set; }
        public bool K { get; set; }
        public bool L { get; set; }
        public bool M { get; set; }
        public bool N { get; set; }
        public bool O { get; set; }
        public bool P { get; set; }
        public bool Q { get; set; }
        public bool R { get; set; }
        public bool S { get; set; }
        public bool T { get; set; }
        public bool U { get; set; }
        public bool V { get; set; }
        public bool W { get; set; }
        public bool X { get; set; }
        public bool Y { get; set; }
        public bool Z { get; set; }
        public bool Space { get; set; }
        public bool LShift { get; set; }
        public bool RShift { get; set; }
        public bool _1 { get; set; }
        public bool _2 { get; set; }
        public bool _3 { get; set; }
        public bool _4 { get; set; }
        public bool _5 { get; set; }
        public bool _6 { get; set; }
        public bool _7 { get; set; }
        public bool _8 { get; set; }
        public bool _9 { get; set; }
        public bool _0 { get; set; }
        /*
        public bool Middle_MouseButton { get; set; }
        public bool Right_MouseButton { get; set; }      Replaced to the core class
        public bool Left_MouseButton { get; set; }
        */

        /// <summary>
        /// Enable User-Input to the Game
        /// </summary>
        public void EnableInput()
        {
            Space = ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0) ? true : false;
            LShift = ((Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) > 0) ? true : false;
            RShift = ((Keyboard.GetKeyStates(Key.RightShift) & KeyStates.Down) > 0) ? true : false;
            Down = ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0) ? true : false;
            Up = ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0) ? true : false;
            Left = ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0) ? true : false;
            Right = ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0) ? true : false;
            Q = ((Keyboard.GetKeyStates(Key.Q) & KeyStates.Down) > 0) ? true : false;
            _1 = ((Keyboard.GetKeyStates(Key.D1) & KeyStates.Down) > 0) ? true : false;
            _2 = ((Keyboard.GetKeyStates(Key.D2) & KeyStates.Down) > 0) ? true : false;
            _3 = ((Keyboard.GetKeyStates(Key.D3) & KeyStates.Down) > 0) ? true : false;
            _4 = ((Keyboard.GetKeyStates(Key.D4) & KeyStates.Down) > 0) ? true : false;
            _5 = ((Keyboard.GetKeyStates(Key.D5) & KeyStates.Down) > 0) ? true : false;
            _6 = ((Keyboard.GetKeyStates(Key.D6) & KeyStates.Down) > 0) ? true : false;
            _7 = ((Keyboard.GetKeyStates(Key.D7) & KeyStates.Down) > 0) ? true : false;
            _8 = ((Keyboard.GetKeyStates(Key.D8) & KeyStates.Down) > 0) ? true : false;
            _9 = ((Keyboard.GetKeyStates(Key.D9) & KeyStates.Down) > 0) ? true : false;
            _0 = ((Keyboard.GetKeyStates(Key.D0) & KeyStates.Down) > 0) ? true : false;
            W = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0) ? true : false;
            E = ((Keyboard.GetKeyStates(Key.E) & KeyStates.Down) > 0) ? true : false;
            R = ((Keyboard.GetKeyStates(Key.R) & KeyStates.Down) > 0) ? true : false;
            T = ((Keyboard.GetKeyStates(Key.T) & KeyStates.Down) > 0) ? true : false;
            Y = ((Keyboard.GetKeyStates(Key.Y) & KeyStates.Down) > 0) ? true : false;
            U = ((Keyboard.GetKeyStates(Key.U) & KeyStates.Down) > 0) ? true : false;
            I = ((Keyboard.GetKeyStates(Key.I) & KeyStates.Down) > 0) ? true : false;
            O = ((Keyboard.GetKeyStates(Key.O) & KeyStates.Down) > 0) ? true : false;
            P = ((Keyboard.GetKeyStates(Key.P) & KeyStates.Down) > 0) ? true : false;
            A = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0) ? true : false;
            S = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0) ? true : false;
            D = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0) ? true : false;
            F = ((Keyboard.GetKeyStates(Key.F) & KeyStates.Down) > 0) ? true : false;
            G = ((Keyboard.GetKeyStates(Key.G) & KeyStates.Down) > 0) ? true : false;
            H = ((Keyboard.GetKeyStates(Key.H) & KeyStates.Down) > 0) ? true : false;
            J = ((Keyboard.GetKeyStates(Key.J) & KeyStates.Down) > 0) ? true : false;
            K = ((Keyboard.GetKeyStates(Key.K) & KeyStates.Down) > 0) ? true : false;
            L = ((Keyboard.GetKeyStates(Key.L) & KeyStates.Down) > 0) ? true : false;
            Z = ((Keyboard.GetKeyStates(Key.Z) & KeyStates.Down) > 0) ? true : false;
            X = ((Keyboard.GetKeyStates(Key.X) & KeyStates.Down) > 0) ? true : false;
            C = ((Keyboard.GetKeyStates(Key.C) & KeyStates.Down) > 0) ? true : false;
            V = ((Keyboard.GetKeyStates(Key.V) & KeyStates.Down) > 0) ? true : false;
            B = ((Keyboard.GetKeyStates(Key.B) & KeyStates.Down) > 0) ? true : false;
            N = ((Keyboard.GetKeyStates(Key.N) & KeyStates.Down) > 0) ? true : false;
            M = ((Keyboard.GetKeyStates(Key.M) & KeyStates.Down) > 0) ? true : false;
           /*
            if (Mouse.LeftButton > 0)
            {
                Left_MouseButton = true;
            }                                     this method is no longer working (replaced mouse input detection to the core class)
            else
            {
                Left_MouseButton = false;
            }
            */
        }

    }
}