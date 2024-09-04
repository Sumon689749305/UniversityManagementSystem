using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.Models;

namespace UniversityManagementSystem.DLL.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure many-to-many relationship
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(pc => new {pc.ProductId,pc.CategoryId});

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(pc => pc.Category)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(pc=> pc.CategoryId);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
    }
}
