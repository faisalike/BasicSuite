using ShopSuite.Repositories.Interfaces;
using ShopSuite.Services.Interfaces;
using ShopSuite.Shared.Dto.Auth;
using System.Security.Cryptography;
using System.Text;
using ShopSuite.Shared;
using AuthMapper = ShopSuite.Repositories.Mappers.AuthMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShopSuite.Services.Settings;

namespace ShopSuite.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtOptions)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<UserDto?> SignUpAsync(string username, string password)
        {
            var existing = await _userRepository.GetByUsernameAsync(username);
            if (existing != null) return null;

            var user = new Domain.Entities.User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                RoleId = UserRole.User
            };
            await _userRepository.AddAsync(user);
            return AuthMapper.ToDto(user);
        }

        public async Task<LoginResponseDto?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || user.PasswordHash != HashPassword(password)) return null;

            var userDto = AuthMapper.ToDto(user);
            var token = GenerateJwtToken(userDto);

            return new LoginResponseDto
            {
                Token = token,
                User = userDto
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private string GenerateJwtToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleName ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}