using Microsoft.AspNetCore.Identity;

namespace ShopSuite.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Role { get; set; }
    }
}