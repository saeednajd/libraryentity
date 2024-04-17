using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Joiddate { get; set; }
        public bool Deleted { get; set; }
        public User(string username,String password)
        {
            Username = username;
            Password = password;
        }
    }
}