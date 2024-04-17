using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public int BookStatus { get; set; }
        public List<BookShelfAndBook> BookShelfAndBooks { get; set; }

        public List<BookShelfAndUser> bookShelfAndUsers { get; set; }
        public List<BookShelfAndShelves> BookShelfAndShelves { get; set; }


    }


}