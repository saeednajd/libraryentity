using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class OneUserBooksView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] Title { get; set; }
    }
}