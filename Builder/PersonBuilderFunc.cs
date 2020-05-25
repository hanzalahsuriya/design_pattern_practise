using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NS_PersonBuilderFunc {
    public class Person {
        public string Name { get; set; }
        public string Position { get; set; }
    }

    public abstract class FunctionalBuilder<T> where T : new () {
        public List<Func<T, T>> actions = new List<Func<T, T>> ();

        public void Do (Action<T> action) => AddAction (action);

        private void AddAction (Action<T> action) {
            actions.Add (t => { action (t); return t; });
        }

        public T Build () {
            return actions.Aggregate (new T (), (t, f) => f (t));
        }
    }

    public class PersonBuilderFunctional1 : FunctionalBuilder<Person> {
        public PersonBuilderFunctional1 SetName (string name) {
            this.Do (p => p.Name = name);
            return this;
        }
    }

    public static class PersonBuilderFunctional1Extensions {
        public static PersonBuilderFunctional1 SetProfession (this PersonBuilderFunctional1 builder, string profession) {
            builder.Do (p => p.Position = profession);
            return builder;
        }
    }

    public class PersonBuilderFunctional {
        public List<Func<Person, Person>> actions = new List<Func<Person, Person>> ();

        public PersonBuilderFunctional AddAction (Action<Person> action) {
            actions.Add (p => { action (p); return p; });
            return this;
        }

        public Person Build () {
            return actions.Aggregate (new Person (), (p, f) => f (p));
        }

        public PersonBuilderFunctional SetName (string name) {
            AddAction (p => p.Name = name);
            return this;
        }
    }

    public static class PersonJobBuilderFunctional {
        public static PersonBuilderFunctional SetProfession (this PersonBuilderFunctional pb, string job) {
            pb.AddAction (p => {
                p.Position = job;
            });
            return pb;
        }
    }

    public class PersonBuilderFunctionalClient {
        public static void Execute () {
            // Open closed 
            var builder = new PersonBuilderFunctional ().SetName ("TTTT").SetProfession ("Soft").Build ();

            // open closed with generics and inheritence
            var builder1 = new PersonBuilderFunctional1 ().SetName ("TTTT").SetProfession ("Soft").Build ();

        }
    }
}