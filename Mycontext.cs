using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Mapping;
using mvc.Models;

namespace mvc
{
    public class Mycontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Shelf> Shelves { get; set; }

        public DbSet<BookShelf> BookShelves { get; set; }
        public DbSet<BookShelfAndBook> BookShelfAndBooks { get; set; }
        public DbSet<BookShelfAndUser> BookShelfAndUsers { get; set; }

        public DbSet<BookShelfAndShelves> BookShelfAndShelves{get ; set ;}

        public Mycontext(DbContextOptions<Mycontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookShelfAndBookConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new BookShelfConfig());
            modelBuilder.ApplyConfiguration(new BookShelfAndBookConfig());
            modelBuilder.ApplyConfiguration(new BookshelfAndShelfconfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}