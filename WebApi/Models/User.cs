using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1WebApi.Models
{
    [Serializable]

    public class User
    {
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Admin";
        public int SecurityLevel { get; set; }

    }
}