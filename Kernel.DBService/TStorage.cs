using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kernel.DBService
{
    [DataContract]
    public class TStorage
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Table { get; protected set; }

        [DataMember]
        public string PKField { get; private set; }

        [DataMember]
        public Dictionary<string, object> Fields { get; private set; }

        public TStorage()
        {
            Fields = new Dictionary<string, object>();
        }
    }
}
