using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Kernel
{
    [Serializable]
    public class TObject
    {
        public int ID { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public TObject()
        {
            Fields = new Dictionary<string, object>();
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DBTableAttribute : Attribute
    {
        public string Table { get; private set; }
        public string PKField { get; private set; }

        public DBTableAttribute(string table, string pk)
        {
            Table = table;
            PKField = pk;
        }
    }
}
