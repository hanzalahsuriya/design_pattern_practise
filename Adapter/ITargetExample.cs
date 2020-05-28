using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Adapter_Example {
    public interface ITarget {
        void Method1 ();
    }

    public interface InCompatibaleInterface {
        void MyMethod ();
    }

    public class InCompatibaleInterfaceAdapter : ITarget {
        private InCompatibaleInterface _inCompatibaleInterface;

        public InCompatibaleInterfaceAdapter (InCompatibaleInterface obj) {
            _inCompatibaleInterface = obj;
        }

        public void Method1 () {
            _inCompatibaleInterface.MyMethod ();
        }
    }

    public class InCompatibaleObj : InCompatibaleInterface {
        public void MyMethod () {
            throw new NotImplementedException ();
        }
    }

    public class Client {
        private ITarget _target;
        public Client (ITarget target) {
            _target = target;
        }

        public void Execute () {
            _target.Method1 ();
        }
    }

    public class ClientMain {
        public static void Execute () {
            // incompatible interface
            InCompatibaleInterface inCompatibaleInterfaceAdapter = new InCompatibaleObj ();

            // adapter which gives compatible implementation from InCompatibaleInterface to ITarget (compatible)
            ITarget target = new InCompatibaleInterfaceAdapter (inCompatibaleInterfaceAdapter);

            // client only understands compatible implementation
            Client client = new Client (target);
        }
    }
}