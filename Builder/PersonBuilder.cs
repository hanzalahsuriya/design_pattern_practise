using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Builder {
    public class Person {
        public string Name { get; set; }
        public string Job { get; set; }

        public override string ToString () {
            return $"Name: {Name} - Job: {Job}";
        }
    }

    public class PersonBuilder {
        protected Person Person = new Person ();

        public PersonBuilder SetName (string name) {
            Person.Name = name;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder {
        public PersonBuilder SetJob (string job) {
            Person.Job = job;
            return this;
        }
    }

    public class PersonBuilderExample {
        public static void Execute () {
            var personBuilder = new PersonJobBuilder ();
            personBuilder.SetJob ("sdfsdf");

        }
    }

}