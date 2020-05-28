using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace RectangelSqrExample {
    public class Square {
        public int Side;
    }

    public interface IRectangle {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods {
        public static int Area (this IRectangle rc) {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle {

        public int Width { get; set; }
        public int Height { get; set; }

        public SquareToRectangleAdapter (Square square) {
            // todo
            Width = Height = square.Side;
        }

        // todo
    }

}