using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Shelf
    {
        public int Identifier { get; set; }
        public string Name { get; set; }

        public Shelf(String name){
            Name = name;
        }
    }
}