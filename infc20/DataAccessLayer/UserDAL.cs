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
        private static readonly Type type = new User().GetType();
        private static Dictionary<string, object> parameters;
        private static string procedure;

        public User GetUser(string email)
        {
            procedure = UserProcedure.GET_USER.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("Email", email);

            List<object> users = Utils.Get(type, procedure, parameters);

            return users.FirstOrDefault() as User;
        }

        public void AddUser(User user)
        {
            procedure = UserProcedure.ADD_USER.ToString();

            if (user != null)
                parameters = Utils.GetParams(user);

            Utils.Insert(procedure, parameters);
        }

        public void UpdateUser(User user)
        {
            procedure = UserProcedure.UPDATE_USER.ToString();

            if (user != null)
                parameters = Utils.GetParams(user);

            Utils.Insert(procedure, parameters);
        }

        public void RemoveUser(string email)
        {
            procedure = UserProcedure.REMOVE_USER.ToString();

            parameters = new Dictionary<string, object>();
            parameters.Add("Email", email);

            Utils.Insert(procedure, parameters);
        }
    }
}
