using infc20.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                                        prop.SetValue(target, dataReader[prop.Name], null);
                                    }
                                    catch (Exception e)
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

        public static Dictionary<string, object> GetParams(object target)
        {
            Dictionary<string, object> parameters = null;
            if (target != null)
            {
                parameters = new Dictionary<string, object>();
                foreach (var prop in target.GetType().GetProperties())
                    parameters.Add(prop.Name, prop.GetValue(target, null));
            }

            return parameters;
        }
    }
}
