using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace ShapeRenderUdemyCodingExcercise {
    public interface IRenderer {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape {
        protected IRenderer Renderer { get; set; }
        public Shape (IRenderer render) {
            Renderer = render;
        }
        public abstract string Name { get; }

        public override string ToString () => $"Drawing {Name} as {Renderer.WhatToRenderAs}";

    }

    public class Triangle : Shape {
        public Triangle (IRenderer render) : base (render) { }

        public override string Name => "Triangle";
    }

    public class Square : Shape {
        public Square (IRenderer render) : base (render) { }
        public override string Name => "Square";

    }

    // no needs for this any more
    // public class VectorSquare : Square {
    //     public VectorSquare (IRenderer render) : base (render) {

    //     }

    //     public override string ToString () => $"Drawing {Name} as lines";
    // }

    // public class RasterSquare : Square {
    //     public RasterSquare (IRenderer render) : base (render) {

    //     }

    //     public override string ToString () => $"Drawing {Name} as pixels";
    // }

    // imagine VectorTriangle and RasterTriangle are here too

    public class ShapeRenderClientClass {
        public static void Execute () {
            IRenderer renderer = new RasterRenderer ();
            Shape sqr = new Square (renderer);

            WriteLine (sqr.ToString ());
        }
    }
}