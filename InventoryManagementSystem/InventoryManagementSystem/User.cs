using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Method to validate the user's credentials
        public bool ValidateCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
