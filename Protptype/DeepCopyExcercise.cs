using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeepCopySerializer {
    public class Point {
        public int X, Y;

        public Point DeepCopy () {
            return new Point () {
                X = X,
                    Y = Y
            };
        }
    }

    public class Line {
        public Point Start, End;

        public Line DeepCopy () {
            return new Line {
                Start = Start.DeepCopy (),
                    End = End.DeepCopy ()
            };
        }
    }
}