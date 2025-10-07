using ShopSuite.Domain.Entities;
using ShopSuite.Shared;
using ShopSuite.Shared.Dto.Auth;

namespace ShopSuite.Repositories.Mappers
{
    public static class AuthMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                RoleId = user.RoleId,
                RoleName = UserRole.GetRoleName(user.RoleId)
            };
        }
    }
}