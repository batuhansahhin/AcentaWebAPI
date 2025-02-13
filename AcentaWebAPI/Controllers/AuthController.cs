using AcentaWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AcentaWebAPI.DataTO;
using AcentaWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AcentaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DemoAcentaDbContext _context;
        private readonly JwtService _jwtService;
        private readonly UserService _userService;

        public AuthController(JwtService jwtService, UserService userService, DemoAcentaDbContext context)
        {
            _jwtService = jwtService;
            _userService = userService;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Kullanıcı adı ve şifre boş olamaz.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            var token = _jwtService.GenerateToken(userDto);

            return Ok(new { Message = "Giriş başarılı", Token = token });
        }
    }
}
