using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace NS_PersonFactory {
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString () {
            return $"Id = {Id} - Name = {Name}";
        }
    }

    public class PersonFactory {
        private static int CurrentId { get; set; } = 0;

        public Person CreatePerson (string name) {
            var person = new Person {
                Id = CurrentId++,
                Name = name
            };

            return person;
        }
    }

    public class PersonFactoryClient {
        public static void Execute () {
            PersonFactory factory = new PersonFactory ();
            var p1 = factory.CreatePerson ("Person1");
            var p2 = factory.CreatePerson ("Person2");
            var p3 = factory.CreatePerson ("Person3");
            var p4 = factory.CreatePerson ("Person4");

            WriteLine (p1);
            WriteLine (p2);
            WriteLine (p3);
            WriteLine (p4);
        }
    }
}