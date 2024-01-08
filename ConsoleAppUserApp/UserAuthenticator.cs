using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUserApp
{
    public class UserAuthenticator
    {
        private List<User> users;

        public UserAuthenticator()
        {
            users = new List<User>();
        }

        public bool RegisterUser(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                return false; // User already exists
            }

            users.Add(new User(username, password));
            return true; // User registered successfully
        }

        public bool Login(string username, string password)
        {
            return users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
