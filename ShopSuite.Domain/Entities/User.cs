using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopSuite.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = default!;

        public class Configuration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(u => u.Id);
                builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
                builder.Property(u => u.PasswordHash).IsRequired();
                builder.HasOne(u => u.Role)
                       .WithMany(r => r.Users)
                       .HasForeignKey(u => u.RoleId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}