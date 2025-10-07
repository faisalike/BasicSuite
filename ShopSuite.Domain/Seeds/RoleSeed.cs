using Microsoft.EntityFrameworkCore;
using ShopSuite.Domain.Entities;
using ShopSuite.Shared;

namespace ShopSuite.Domain.Seeds
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = UserRole.User, Name = UserRole.UserName },
                new Role { Id = UserRole.Admin, Name = UserRole.AdminName }
            );
        }
    }
}