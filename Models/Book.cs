using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public int Pages { get; set; }

        public List<BookShelfAndBook> BookShelfAndBooks{get ; set ;}
        public Book(string title,int pages){
            Title = title;
            Pages = pages;
        }

    }
}