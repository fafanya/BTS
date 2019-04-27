using System;
using System.Data;
using System.Linq;
using System.Data.Odbc;
using System.Configuration;
using System.Collections.Generic;

namespace Kernel.Service
{
    public class TServiceODBC : TServiceDB
    {
        public TServiceODBC()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ODBCConnectionString"].ConnectionString;
        }

        public override int Insert(TStorage obj)
        {
            using (var conn = new OdbcConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new OdbcCommand())
                {
                    cmd.Connection = conn;

                    string fields = string.Empty;
                    string values = string.Empty;
                    for (int i = 0; i < obj.Fields.Count; i++)
                    {
                        var field = obj.Fields.ElementAt(i);
                        if (field.Key == obj.PKField)
                            continue;

                        var prm = cmd.Parameters.AddWithValue(field.Key, field.Value);

                        fields += field.Key;
                        values += "?";

                        if (i != obj.Fields.Count - 1)
                        {
                            fields += " , ";
                            values += " , ";
                        }
                    }

                    cmd.CommandText =
                        "INSERT INTO " + obj.Table + " (" + fields + ") VALUES ( " + values + " ) RETURNING " + obj.PKField;

                    object retVal = cmd.ExecuteScalar();
                    return Convert.ToInt32(retVal);
                }
            }
        }

        public override void Update(TStorage obj)
        {
            using (var conn = new OdbcConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new OdbcCommand())
                {
                    cmd.Connection = conn;

                    string fields = string.Empty;
                    string values = string.Empty;
                    for (int i = 0; i < obj.Fields.Count; i++)
                    {
                        var field = obj.Fields.ElementAt(i);

                        string p = "p" + i.ToString();
                        cmd.Parameters.AddWithValue(p, field.Value);
                        fields += field.Key + "=@" + p;

                        if (i != obj.Fields.Count - 1)
                        {
                            fields += ", ";
                        }
                    }

                    cmd.CommandText =
                        "UPDATE " + obj.Table + " SET " + fields + " WHERE " + obj.PKField + "=" + obj.ID;
                    cmd.ExecuteScalar();
                }
            }
        }

        /*public override void Delete(TStorage obj)
        {
            try
            {
                using (var conn = new OdbcConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new OdbcCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText =
                            "DELETE FROM " + obj.Table + " WHERE " + obj.PKField + "=" + obj.ID;
                        cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }*/

        public override void Delete(TStorage obj)
        {
            try
            {
                DataSet dataSet = new DataSet();
                OdbcConnection conn = new OdbcConnection(ConnectionString);
                conn.Open();
                OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter();
                odbcDataAdapter.SelectCommand = new OdbcCommand("SELECT * FROM " + obj.Table, conn);
                OdbcCommandBuilder ocb = new OdbcCommandBuilder(odbcDataAdapter);
                odbcDataAdapter.Fill(dataSet, obj.Table);
                conn.Close();

                DataTable dt = dataSet.Tables[0];
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dt.Columns[obj.PKField];
                dt.PrimaryKey = keyColumns;
                DataRow dr = dt.Rows.Find(obj.ID);
                dr.Delete();

                conn.ConnectionString = ConnectionString;
                conn.Open();
                odbcDataAdapter.SelectCommand = new OdbcCommand("SELECT * FROM " + obj.Table, conn);
                odbcDataAdapter.Update(dataSet, obj.Table);
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public override TStorage LoadDetails(TStorage query)
        {
            TStorage result = null;
            using (var conn = new OdbcConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new OdbcCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT * FROM " + query.Table + " WHERE " + query.PKField + "=" + query.ID;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        result = new TStorage();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string key = reader.GetName(i);
                            object value = reader.GetValue(i);
                            result.Fields.Add(key, value);
                        }
                    }
                }
            }
            return result;
        }

        public override IEnumerable<TStorage> LoadList(TStorage query)
        {
            List<TStorage> result = new List<TStorage>();
            using (var conn = new OdbcConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new OdbcCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM " + query.Table;

                    if (query.Fields != null && query.Fields.Any())
                    {
                        cmd.CommandText += " WHERE ";

                        string fields = string.Empty;
                        for (int i = 0; i < query.Fields.Count; i++)
                        {
                            var field = query.Fields.ElementAt(i);

                            cmd.Parameters.AddWithValue(string.Empty, field.Value);
                            fields += field.Key + " = ?";

                            if (i != query.Fields.Count - 1)
                            {
                                fields += " AND ";
                            }
                        }
                        cmd.CommandText += fields + ";";
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TStorage s = new TStorage();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string key = reader.GetName(i);
                                object value = reader.GetValue(i);
                                s.Fields.Add(key, value);
                            }
                            result.Add(s);
                        }
                    }
                }
            }
            return result;
        }
    }
}