using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Mapping
{
    public class BookShelfAndBookConfig : IEntityTypeConfiguration<BookShelfAndBook>
    {
        public void Configure(EntityTypeBuilder<BookShelfAndBook> builder)
        {
            builder.ToTable("BookShelfAndBooks");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Books).WithMany(x => x.BookShelfAndBooks).HasForeignKey(x => x.BookID);
            builder.HasOne(x => x.BookShelves).WithMany(x =>x.BookShelfAndBooks).HasForeignKey(x=>x.BookShelfId);
        }
    }
}