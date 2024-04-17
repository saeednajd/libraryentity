using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Mapping
{
    public class BookShelfConfig : IEntityTypeConfiguration<BookShelf>
    {
        public void Configure(EntityTypeBuilder<BookShelf> builder)
        {
            builder.ToTable("bookShelves");
            builder.HasKey(x=>x.Id);
            
        }
    }
}