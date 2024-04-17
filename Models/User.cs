using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace mvc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Joindate { get; set; }
        public bool Deleted { get; set; }
        public List<BookShelfAndUser> bookShelfAndUsers{get; set ;}
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Joindate = DateTime.UtcNow;
            Deleted = false;
        }
    }
}