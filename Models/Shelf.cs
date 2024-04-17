using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookShelfAndShelves> BookShelfAndShelves {get;set;}
        public Shelf(String name){
            Name = name;
        }
    }
}