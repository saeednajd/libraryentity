using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class BookShelfAndBook
    {
        public int Id { get; set; }
        public int BookShelfId { get; set; }
        public BookShelf BookShelves { get; set; }
        public int BookID { get; set; }
        public Book Books { get; set; }
    }
}