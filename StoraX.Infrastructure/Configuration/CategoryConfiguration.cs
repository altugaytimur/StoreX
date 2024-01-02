using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category() { Id = 1, CategoryName = "Book" },
                    new Category() { Id = 2, CategoryName = "Electronic" }

                );

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoryName).IsRequired();
        }
    }
}
