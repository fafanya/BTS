using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Common;

namespace BTS.Common
{
    [DBTable("route_mark")]
    public class RouteMark : TObject
    {
        public static TField KeyParm = new TField("route_mark_id", "ID", TFieldType.PK);
        public static TField BarcodeParm = new TField("barcode", "Штрихкод", TFieldType.Name);
        public static TField StampParm = new TField("stamp", "Дата", TFieldType.None);
        public static TField RoutePointParm = new TField("route_point", "Точка учёта", TFieldType.None);

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
        public string Barcode
        {
            get
            {
                return Values[BarcodeParm] as string;
            }
            set
            {
                Values[BarcodeParm] = value;
            }
        }
        public DateTime? Stamp
        {
            get
            {
                return Values[StampParm] as DateTime?;
            }
            set
            {
                Values[StampParm] = value;
            }
        }
        public string RoutePoint
        {
            get
            {
                return Values[RoutePointParm] as string;
            }
            set
            {
                Values[RoutePointParm] = value;
            }
        }
    }
}