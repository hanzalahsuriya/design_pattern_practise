using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace PersonClonableExample {
    public class Person : ICloneable {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person (string[] names, Address address) {
            Names = names;
            Address = address;
        }

        public object Clone () {
            return new Person (Names, (Address) Address.Clone ());
        }

        public override string ToString () {
            return $"{string.Join(" ",Names)} - Address: {Address}";
        }
    }

    public class Address : ICloneable {
        public int HouseNumber { get; set; }
        public string Street { get; set; }

        public Address (int houseNumber, string street) {
            HouseNumber = houseNumber;
            Street = street;
        }

        public object Clone () {
            return new Address (HouseNumber, Street);
        }

        public override string ToString () {
            return $"HouseNumber: {HouseNumber} - Street {Street}";
        }
    }

    public class ClonablePeronClient {
        public static void Execute () {
            var person1 = new Person (new string[] { "John", "cena" }, new Address (12, "xaviour road"));
            var person2 = person1.Clone ();
            person1.Address.HouseNumber = 500;

            WriteLine (person1);
            WriteLine (person2);
        }
    }
}