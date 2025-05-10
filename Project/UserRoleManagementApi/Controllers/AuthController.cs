using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserRoleManagementApi.Models;
using UserRoleManagementApi.Services.Interfaces;

namespace UserRoleManagementApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Find user by email
            var users = await _userService.GetAllUsersWithRolesAsync();
            var user = users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null || user.Password != request.Password)
                return Unauthorized();

            var role = user.UserRoles.FirstOrDefault()?.Role?.Name ?? "User";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "super_secret_key_12345678901234567890123456789012!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"] ?? "UserRoleManagementApi",
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var existingUsers = await _userService.GetAllUsersWithRolesAsync();
            if (existingUsers.Any(u => u.Username == request.Username || u.Email == request.Email))
                return Conflict("Username or email already exists.");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password 
            };
            var created = await _userService.CreateUserAsync(user);
            return Ok(new { created.Id, created.Username, created.Email });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
