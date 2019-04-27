using System;
using System.Collections.Generic;
using BTS.Client.TrackingService;
using BTS.Common;
using Kernel.Common;

namespace BTS.Client
{
    public class TrackingClient : ClientBase
    {
        private TrackingClient() { }
        private static TrackingClient m_Instance = null;
        public static TrackingClient Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = new TrackingClient();
                }
                return m_Instance;
            }
        }

        public object CreateRouteMark(RouteMark routeMark)
        {
            return InsertObject(routeMark);
        }

        public void DeleteRouteMark(RouteMark routeMark)
        {
            DeleteObject<RouteMark>(routeMark);
        }

        public IEnumerable<RouteMark> LoadRouteMarkList(Dictionary<string, object> filter = null)
        {
            return LoadObjectList<RouteMark>(filter);
        }

        public IEnumerable<RouteSheet> LoadRouteSheetList(Dictionary<string, object> filter = null)
        {
            return LoadObjectList<RouteSheet>(filter);
        }

        public RouteMark LoadRouteMark(int id)
        {
            return LoadObject<RouteMark>(id);
        }

        public void DownloadReport(string fileName)
        {
            IEnumerable<RouteMark> rmList = LoadRouteMarkList();
            ExcelMaker.CreateFile(rmList, fileName);
        }
    }

    public class ClientBase
    {
        public static object InsertObject<T>(T obj) where T : TObject
        {
            DBTableAttribute dbTableAttribute =
                (DBTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DBTableAttribute));

            TStorage tStorage = new TStorage
            {
                Fields = obj.GetKeyValuePairs(),
                Table = dbTableAttribute.Table,
                PKField = obj.GetKeyField()
            };

            TrackingServiceClient tsc = new TrackingServiceClient();
            return tsc.Insert(tStorage);
        }

        public static IEnumerable<T> LoadObjectList<T>(Dictionary<string, object> filter = null) where T : TObject
        {
            DBTableAttribute dbTableAttribute =
                (DBTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DBTableAttribute));

            TStorage tStorage = new TStorage
            {
                Fields = filter,
                Table = dbTableAttribute.Table
            };

            TrackingServiceClient tsc = new TrackingServiceClient();
            IEnumerable<TStorage> tStorageList = tsc.LoadList(tStorage);

            List<T> result = new List<T>();
            foreach (TStorage s in tStorageList)
            {
                var ctor = typeof(T).GetConstructor(new Type[] { });
                var item = ctor.Invoke(new object[] { }) as T;
                item.SetKeyValuePairs(s.Fields);
                item.SetKeyValue(s.Fields[item.GetKeyField()]);
                result.Add(item);
            }

            return result;
        }

        public static T LoadObject<T>(int id) where T : TObject
        {
            DBTableAttribute dbTableAttribute =
                (DBTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DBTableAttribute));

            TStorage tStorage = new TStorage
            {
                ID = id,
                Table = dbTableAttribute.Table
            };

            TrackingServiceClient tsc = new TrackingServiceClient();
            TStorage tObjStorage = tsc.LoadDetails(tStorage);
            var ctor = typeof(T).GetConstructor(new Type[] { });
            var result = ctor.Invoke(new object[] { }) as T;
            result.SetKeyValuePairs(tObjStorage.Fields);

            return result;
        }

        public static void DeleteObject<T>(T obj) where T : TObject
        {
            try
            {
                DBTableAttribute dbTableAttribute =
                    (DBTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DBTableAttribute));

                TStorage tStorage = new TStorage
                {
                    ID = Convert.ToInt32(obj.GetKeyValue()),
                    Table = dbTableAttribute.Table,
                    PKField = obj.GetKeyField()
                };

                TrackingServiceClient tsc = new TrackingServiceClient();
                tsc.Delete(tStorage);
            }
            catch(Exception ex)
            {

            }
        }
    }
}