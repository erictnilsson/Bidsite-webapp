using infc20.Model;
using infc20.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.DataAccessLayer
{
    class UserDAL
    {
        private static Type type = new User().GetType();
        private static Dictionary<string, object> parameters;
        private static string procedure;
        private static string[] exceptionParams;

        public static User GetUser(string email)
        {
            procedure = UserProcedure.GET_USER.ToString();
            parameters = new Dictionary<string, object>(); 
            parameters.Add("Email", email);

            return Utils.Get(type, procedure, parameters).FirstOrDefault() as User;
        }

        public static void AddUser(User user)
        {
            procedure = UserProcedure.ADD_USER.ToString();
            if (user != null)
                parameters = Utils.GetParams(user, exceptionParams);

            Utils.Insert(procedure, parameters);
        }

        public static void UpdateUser(User user)
        {
            procedure = UserProcedure.UPDATE_USER.ToString();

            if (user != null)
                parameters = Utils.GetParams(user, exceptionParams);

            Utils.Insert(procedure, parameters);
        }

        public static void RemoveUser(string email)
        {
            procedure = UserProcedure.REMOVE_USER.ToString();
            parameters = new Dictionary<string, object>(); 
            parameters.Add("Email", email);

            Utils.Insert(procedure, parameters);
        }
    }
}
