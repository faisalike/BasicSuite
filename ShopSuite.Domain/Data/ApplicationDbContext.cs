using Microsoft.EntityFrameworkCore;
using ShopSuite.Domain.Entities;
using ShopSuite.Domain.Seeds;

namespace ShopSuite.Domain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new User.Configuration());
            modelBuilder.ApplyConfiguration(new Product.Configuration());
            modelBuilder.ApplyConfiguration(new Role.Configuration());

            // Seed roles
            RoleSeed.Seed(modelBuilder);
        }
    }
}