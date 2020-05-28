using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using static System.Console;
using System.Threading.Tasks;

namespace IsSingeltonExcercice {
    public class SingletonTester {
        public static bool IsSingleton (Func<object> func) {

            var obj1 = func ();
            var obj2 = func ();

            return obj1.Equals (obj2);

        }
    }
}