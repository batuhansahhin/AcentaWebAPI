using System;
using AcentaWebAPI.DataTO;
using AcentaWebAPI.DTOs;
using AcentaWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcentaWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DemoAcentaDbContext _context;

        public UserController(DemoAcentaDbContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public IActionResult ActionInfo()
        {
            try
            {
                var userName = User.Identity?.Name;
                if (string.IsNullOrEmpty(userName))
                {
                    return Unauthorized(new
                    {
                        Message = "Kullanıcı bilgileri alınamadı."
                    });
                }
                return Ok(new
                {
                    Message = "Giriş yapmış kullanıcı",
                    User = userName
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Bir hata oluştu: " + ex.Message
                });
            }
        }

        [AllowAnonymous] 
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.UserName == request.UserName || u.Email == request.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { Message = "Bu kullanıcı adı veya e-posta zaten kullanılıyor." });
                }

                var newUser = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    UserTypeId = request.UserTypeId
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Kullanıcı başarıyla eklendi.", UserId = newUser.UserId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Kullanıcı oluşturulurken bir hata oluştu: " + ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _context.Users
                    .Where(u => !u.IsDeleted) 
                    .Select(u => new
                    {
                        u.UserId,
                        u.UserName,
                        u.Email,
                        u.FirstName,
                        u.LastName,
                        u.UserTypeId
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.UserId == id && !u.IsDeleted)
                    .Select(u => new
                    {
                        u.UserId,
                        u.UserName,
                        u.Email,
                        u.FirstName,
                        u.LastName,
                        u.UserTypeId
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new { Message = "Kullanıcı bulunamadı." });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu: " + ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null || user.IsDeleted)
                {
                    return NotFound(new
                    {
                        Message = "Kullanıcı bulunamadı."
                    });
                }

                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;
                user.Email = request.Email ?? user.Email;
                user.UserTypeId = request.UserTypeId ?? user.UserTypeId;

                if(!string.IsNullOrEmpty(request.Password))
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                }

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Kullanıcı bilgileri güncellendi."
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null || user.IsDeleted)
                {
                    return NotFound(new { Message = "Kullanıcı bulunamadı." });
                }

                user.IsDeleted = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Kullanıcı başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu: " + ex.Message });
            }
        }
    }
}
