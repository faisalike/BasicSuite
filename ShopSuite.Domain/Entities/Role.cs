using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ShopSuite.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<User> Users { get; set; } = new List<User>();

        public class Configuration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasKey(r => r.Id);
                builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
                builder.HasMany(r => r.Users)
                       .WithOne(u => u.Role)
                       .HasForeignKey(u => u.RoleId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}