using infc20.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Utilities
{
    static class Utils
    {
        public static List<object> Get(Type targetType, string procedureCommand, Dictionary<string, object> parameters)
        {
            List<object> tuples = new List<object>();
            using (SqlConnection con = Connector.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(procedureCommand, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var entry in parameters)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read() && dataReader.HasRows)
                        {
                            var target = Activator.CreateInstance(targetType);
                            foreach (var prop in target.GetType().GetProperties())
                            {
                                if (prop != null && prop.CanWrite)
                                {
                                    try
                                    {
                                        var v = dataReader[prop.Name];
                                        prop.SetValue(target, dataReader[prop.Name], null);
                                    }
                                    catch (IndexOutOfRangeException e)
                                    {
                                        continue;
                                    }
                                }
                            }
                            tuples.Add(target);
                        }
                    }
                }
            }
            return tuples;
        }

        public static void Insert(string procedureCommand, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = Connector.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(procedureCommand, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var entry in parameters)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<string, object> GetParams(object target, string[] exceptions)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (target != null)
            {
                foreach (var prop in target.GetType().GetProperties())
                {
                    if (exceptions == null)
                        parameters.Add(prop.Name, prop.GetValue(target, null));

                    else if (exceptions != null && !exceptions.Contains<string>(prop.Name))
                        parameters.Add(prop.Name, prop.GetValue(target, null));

                    else continue;


                }
            }
            return parameters;
        }
    }
}
