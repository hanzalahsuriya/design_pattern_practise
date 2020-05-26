using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_FactoryMethod {

    public class Point {
        public double X { get; set; }

        public double Y { get; set; }
        public Point (double x, double y) {
            this.X = x;
            this.Y = y;
        }

        // property getter
        public static Point Origin => new Point (0, 0);

        // Field
        public static Point Origin2 = new Point (0, 0);

        private async Task<Point> InitAsync () {
            await Task.Delay (100);
            return this;
        }

        public static Task<Point> InitAsync (double x, double y) {
            var p = new Point (x, y);
            return p.InitAsync ();
        }

        public override string ToString () {
            return $"point - {X} , {Y}";
        }

        public static class Factory {
            public static Point CreateNewCartisionSystem (double x, double y) {
                return new Point (x, y);
            }

            public static Point CreateNewPolarSystemn (double x, double y) {
                return new Point (x * Math.Cos (y), y);
            }
        }
    }

    public class PointFactoryMethodClient {
        public void Execute () {
            // innter factory class like Task.Factory.CreateNew....

            var cartesianPoint = Point.Factory.CreateNewCartisionSystem (1, 2);
            var polarPpoint = Point.Factory.CreateNewPolarSystemn (4, 5);

            var asyncPoint = Point.InitAsync (1, 2).Result;

            var p = Point.Origin2;
        }
    }
}