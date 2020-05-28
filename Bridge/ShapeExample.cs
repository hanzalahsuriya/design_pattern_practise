using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace BridgeShapeExample {
    public interface IRender {
        void Render ();
    }

    public class VectorRender : IRender {
        public void Render () {
            Write ("VectorRender:IRender");
        }
    }

    public class PixelRender : IRender {
        public void Render () {
            Write ("PixelRender:IRender");
        }
    }

    public abstract class Shape {
        public abstract void Draw ();
    }

    public class Circle : Shape {
        private IRender _render;
        public Circle (IRender render) {
            _render = render;
        }

        public override void Draw () {
            WriteLine ("Drawing Circle");
            _render.Render ();
        }
    }

    // no need to create more child 

    public class Client {
        public static void Execute () {
            IRender vectorRender = new VectorRender ();
            Shape circle = new Circle (vectorRender);

            circle.Draw ();
        }
    }

}