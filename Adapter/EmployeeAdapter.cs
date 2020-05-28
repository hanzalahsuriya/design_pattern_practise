using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace EmployeeAdapterExample {
    public interface IThirdPartyEmployeeSource {
        List<string> GetEmployees ();
    }

    public class ThirdPartyBillingSystem {
        private IThirdPartyEmployeeSource _source;
        public ThirdPartyBillingSystem (IThirdPartyEmployeeSource source) {
            _source = source;
        }

        public void ShowEmployees () {
            var list = _source.GetEmployees ();
            foreach (var e in list) {
                WriteLine (e);
            }
        }
    }

    public class MyFinanceSystem {
        public List<string> GetEmpl () {
            return new List<string> {
                "Dave",
                "Jane",
                "Jim"
            };
        }
    }

    // Adapter1
    public class MyFinanceSystemToIThirdPartyEmployeeSourceAdapter1 : MyFinanceSystem, IThirdPartyEmployeeSource {
        public List<string> GetEmployees () {
            return this.GetEmpl ();
        }
    }

    // Adapter2
    public class MyFinanceSystemToIThirdPartyEmployeeSourceAdapter2 : IThirdPartyEmployeeSource {
        private readonly MyFinanceSystem _myFinanceSystem;
        public MyFinanceSystemToIThirdPartyEmployeeSourceAdapter2 (MyFinanceSystem myFinanceSystem) {
            _myFinanceSystem = myFinanceSystem;
        }
        public List<string> GetEmployees () {
            return _myFinanceSystem.GetEmpl ();
        }
    }

    public class ThirdPartyBillingSystemClient {
        public void Execute () {
            // should be adapter because thridPartySystem only understand IThirdPartyEmployeeSource
            // we have MyFinanceSystem and not IThirdPartyEmployeeSource
            // we need adapter that converts MyFinanceSystem to IThirdPartyEmployeeSource
            // so adapter is a class which implements IThirdPartyEmployeeSource
            // now this adapter will either take MyFinanceSystem as constructor or it will inherit from it
            IThirdPartyEmployeeSource source = new MyFinanceSystemToIThirdPartyEmployeeSourceAdapter1 ();
            ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem (source);

            IThirdPartyEmployeeSource source2 = new MyFinanceSystemToIThirdPartyEmployeeSourceAdapter2 (new MyFinanceSystem ());
            thirdPartyBillingSystem = new ThirdPartyBillingSystem (source2);

        }
    }
}