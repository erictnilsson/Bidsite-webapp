using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class Connector
    {
        private static readonly string username = "sadmin",
                                       password = "super",
                                       database = "infc20",
                                       server = "DESKTOP-MNFMFBJ\\SQLEXPRESS", //DESKTOP-MNFMFBJ\SQLEXPRESS
                                       url = "user id = " + username + ";" +
                                             "password = " + password + ";" +
                                             "server = " + server + ";" +
                                             "database = " + database + ";" +
                                             "connection timeout = 10;";

        public static SqlConnection Connect()
        {
            try
            {
                SqlConnection con = new SqlConnection(url);
                con.Open();
                Console.WriteLine("Connection opened");
                return con;
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return null;
        }
    }
}
