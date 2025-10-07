using ShopSuite.Domain.Entities;
using ShopSuite.Shared.Dto.Auth;
using System.Threading.Tasks;

namespace ShopSuite.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto?> SignUpAsync(string username, string password);
        Task<LoginResponseDto?> LoginAsync(string username, string password);
    }
}