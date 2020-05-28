using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace NS_ShapeColor {
    public interface IColor {
        void Paint ();
    }

    public class Blue : IColor {
        public void Paint () {
            WriteLine ("I am blue color");
        }
    }

    public class Red : IColor {
        public void Paint () {
            WriteLine ("I am Red Color");
        }
    }

    public interface IShape {
        IColor Color { get; }

        void Draw ();
    }

    public class Circle : IShape {
        public IColor Color { get; private set; }

        public Circle (IColor color) {
            this.Color = color;
        }

        public void Draw () {
            WriteLine ("Drawing Circle in");
            Color.Paint ();
        }
    }

    public class Square : IShape {
        public IColor Color { get; private set; }

        public void Draw () {
            WriteLine ("Drawing Square in");
            Color.Paint ();
        }
    }

    public class ClientShape {
        public static void Execute () {
            IColor colorRed = new Red ();

            IShape redCircle = new Circle (colorRed);

            redCircle.Draw ();
        }
    }
}