using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.API.Models;

namespace UniversityManagementSystem.DLL.Configs
{
    public class CategoryProductConfigaration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            //Configure many-to-many relationship
            builder
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder
                .HasOne(pc => pc.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(pc => pc.ProductId);

            builder
                .HasOne(pc => pc.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
