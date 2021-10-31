using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    [Serializable]

    public class User
    {
        public User()
        {
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Admin";
        public int SecurityLevel { get; set; }

    }
}