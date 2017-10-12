using infc20.DataAccessLayer;
using infc20.Model;
using infc20.Utilities;
using System;

namespace infc20
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDAL.AddUser(null); 
            Console.Read(); 
        }
    }
}
