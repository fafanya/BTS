using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Common;

namespace BTS.Common
{
    [DBTable("v$route_sheet")]
    public class RouteSheet : TObject
    {
        public TField KeyParm = new TField("barcode", "ID", TFieldType.PK);

        public object Key
        {
            get
            {
                return Values[KeyParm];
            }
            set
            {
                Values[KeyParm] = value;
            }
        }
    }
}