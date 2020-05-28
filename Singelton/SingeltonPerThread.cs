using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using static System.Console;
using System.Threading.Tasks;

namespace NS_SigeltonPerThread {
    public class SignLocal {
        private SignLocal () {

        }

        private static ThreadLocal<SignLocal> _in = new ThreadLocal<SignLocal> (() => new SignLocal ());

        public int GetCurrentThreadId () {
            return Thread.CurrentThread.ManagedThreadId;
        }

        public static SignLocal Instance => _in.Value;

    }

    public class SignLocalClient {
        public static void Execute () {
            Task.Factory.StartNew (() => {
                WriteLine ("t1: " + SignLocal.Instance.GetCurrentThreadId ());
                WriteLine ("t1: " + SignLocal.Instance.GetCurrentThreadId ());
            });

            Task.Factory.StartNew (() => {
                WriteLine ("t2: " + SignLocal.Instance.GetCurrentThreadId ());
                WriteLine ("t2: " + SignLocal.Instance.GetCurrentThreadId ());
            });
        }
    }
}