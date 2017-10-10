using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infc20.Model
{
    class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public User() { }
        public User(string email, string firstName, string lastName, string address)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
    }
}
