using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace BasicSingelton {
    public interface IDatabase {
        int GetCityPopulation (string city);
    }

    public class DatabaseImpl : IDatabase {
        private Dictionary<string, int> _cities;

        private DatabaseImpl () {
            _cities = new Dictionary<string, int> { { "Karachi", 1 },
                { "London", 2 },
                { "New York", 5 }
            };
        }

        public int GetCityPopulation (string city) {
            return this._cities[city];
        }

        private static Lazy<IDatabase> _instance = new Lazy<IDatabase> (() => new DatabaseImpl ());

        public static IDatabase Instance => _instance.Value;
    }

    public class SingeltonClient {
        public static void Execute () {
            var db = DatabaseImpl.Instance;
            var city = "Karachi";
            WriteLine ($"City: {city} , Population: {db.GetCityPopulation (city)}");
        }
    }
}