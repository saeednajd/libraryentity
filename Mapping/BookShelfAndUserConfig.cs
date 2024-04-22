using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Mapping
{
    public class BookShelfAndUserConfig : IEntityTypeConfiguration<BookShelfAndUser>
    {
        public void Configure(EntityTypeBuilder<BookShelfAndUser> builder)
        {
            builder.ToTable("BookShelfAndUsers");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(x => x.bookShelfAndUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x=>x.BookShelf).WithMany(x=>x.bookShelfAndUsers).HasForeignKey(x=>x.BookShelfId);
        }
    }
}