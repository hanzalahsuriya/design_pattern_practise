using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace NS_AbstractFactory {
    public enum HotDrinkType {
        Tea,
        Coffee
    }

    public interface IHotDrink {
        void Prepare (int amount);
    }

    public class Tea : IHotDrink {
        public void Prepare (int amount) {
            WriteLine ($"Preparing tea : {amount}");
        }
    }

    public class Coffee : IHotDrink {
        public void Prepare (int amount) {
            WriteLine ($"Preparing tea : {amount}");
        }
    }

    public interface IHotDrinkFactory {
        IHotDrink Create ();

        HotDrinkType HotDrinkType { get; }
    }

    public class TeaFactory : IHotDrinkFactory {
        public IHotDrink Create () {
            return new Tea ();
        }

        public HotDrinkType HotDrinkType => HotDrinkType.Tea;
    }

    public class CoffeeFactory : IHotDrinkFactory {
        public IHotDrink Create () {
            return new Coffee ();
        }

        public HotDrinkType HotDrinkType => HotDrinkType.Coffee;
    }

    public class HotDrinkMaker {
        private readonly List<IHotDrinkFactory> _hotDrinkFactories;
        public HotDrinkMaker () {
            // this will be injected by DI
            this._hotDrinkFactories = new List<IHotDrinkFactory> () {
                new TeaFactory (),
                new CoffeeFactory ()
            };
        }

        public IHotDrink MakeHotDrink (HotDrinkType type) {
            return this._hotDrinkFactories.First (x => x.HotDrinkType == type).Create ();
        }
    }

    public class Client {
        public void Execute () {
            HotDrinkMaker hotDrinkMaker = new HotDrinkMaker ();
            var tea = hotDrinkMaker.MakeHotDrink (HotDrinkType.Tea);
            var coffee = hotDrinkMaker.MakeHotDrink (HotDrinkType.Coffee);
        }
    }

}