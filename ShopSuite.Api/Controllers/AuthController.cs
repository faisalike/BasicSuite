using Microsoft.AspNetCore.Mvc;
using ShopSuite.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopSuite.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            // Assign a default RoleId (e.g., 1 for "User") if not handled in service
            var user = await _authService.SignUpAsync(request.Username, request.Password);
            if (user == null) return BadRequest("Username already exists or role assignment failed.");
            return Ok(new { user.Id, user.Username, user.RoleId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginResult = await _authService.LoginAsync(request.Username, request.Password);
            if (loginResult == null) return Unauthorized();
            return Ok(new
            {
                token = loginResult.Token,
                user = new
                {
                    loginResult.User.Id,
                    loginResult.User.Username,
                    loginResult.User.RoleId,
                    loginResult.User.RoleName
                }
            });
        }
    }

    public class SignUpRequest
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class LoginRequest
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}