using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NS_CodeBuilder {

    public class CodeBuilder {
        private string _entityName;

        public CodeBuilder (string entityName) {
            this._entityName = entityName;
        }

        // private List < (string, string) > _fields = new List < (string, string) > ();
        private List<string> _fields = new List<string> ();

        public CodeBuilder AddField (string property, string type) {
            // _fields.Add ((property, type));
            _fields.Add ($"  public {type} {property};");
            return this;
        }

        public override string ToString () {
            return ToStringImpl ();
        }

        private string ToStringImpl () {
            StringBuilder sb = new StringBuilder ();
            sb.AppendLine ($"public class {_entityName}");
            sb.AppendLine (@"{");
            foreach (var field in _fields) {
                sb.AppendLine (field);
            }
            sb.Append (@"}");
            return sb.ToString ();
        }
    }

    public class CodeBuilderClient {
        public static void Execute () {
            var cb = new CodeBuilder ("Person").AddField ("Name", "string").AddField ("Age", "int");
            Console.WriteLine (cb);
        }
    }

}