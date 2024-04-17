using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Mapping
{
    public class BookshelfAndShelfconfig : IEntityTypeConfiguration<BookShelfAndShelves>
    {
        public void Configure(EntityTypeBuilder<BookShelfAndShelves> builder)
        {
            builder.ToTable("BookShelfAndShelves");
            builder.HasKey(x => new { x.BookshelfId, x.ShelfId });

            builder.HasOne(x => x.BookShelf).WithMany(x => x.BookShelfAndShelves).HasForeignKey(x => x.BookshelfId);
            builder.HasOne(x => x.Shelf).WithMany(x => x.BookShelfAndShelves).HasForeignKey(x=>x.ShelfId);
            


        }
    }
}