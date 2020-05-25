using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NS_FacetBuilder {
    public class Person {
        public string Name { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Profession { get; set; }

        public decimal Income { get; set; }

        public string Office { get; set; }
    }

    public class PersonBuilderFacet {
        protected Person Person = new Person ();

        public PersonAddressBuilder At => new PersonAddressBuilder (this.Person);

        public PersonProfessionBuilder As => new PersonProfessionBuilder (Person);

        public static implicit operator Person (PersonBuilderFacet pb) {
            return pb.Person;
        }
    }

    public class PersonAddressBuilder : PersonBuilderFacet {
        public PersonAddressBuilder (Person person) {
            this.Person = person;
        }

        public PersonAddressBuilder Street (string street) {
            Person.Street = street;
            return this;
        }

        public PersonAddressBuilder Name (string name) {
            Person.Name = name;
            return this;
        }

        public PersonAddressBuilder PostCode (string postCode) {
            Person.PostCode = postCode;
            return this;
        }
    }

    public class PersonProfessionBuilder : PersonBuilderFacet {
        public PersonProfessionBuilder (Person person) {
            this.Person = person;
        }

        public PersonProfessionBuilder Profession (string profession) {
            Person.Profession = profession;
            return this;
        }

        public PersonProfessionBuilder Income (decimal income) {
            Person.Income = income;
            return this;
        }

        public PersonProfessionBuilder Office (string office) {
            Person.Office = office;
            return this;
        }
    }

    public class PersonFacetBuilderClient {
        public void Execite () {
            var builder = new PersonBuilderFacet ();
            Person person = builder.At.Name ("").PostCode ("").Street ("").As.Profession ("").Office ("").Income (0);
        }
    }
}