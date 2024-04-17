using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc
{
    public class Mycontext:DbContext
    {
       public  DbSet<User>  Users { get; set; }

       public Mycontext(DbContextOptions<Mycontext> options) : base(options)
       {

       }
        
    }
}