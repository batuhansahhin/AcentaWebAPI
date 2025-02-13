using System.Security.Cryptography;
using System.Text;
using AcentaWebAPI.DataTO;
using AcentaWebAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace AcentaWebAPI.Services
{
    public class UserService
    {
        private readonly DemoAcentaDbContext _context;

        public UserService(DemoAcentaDbContext context)
        {
            _context = context;
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public async Task<bool> RegisterUser(DataTO.RegisterRequest request)
        {
            try
            {

                if (await _context.Users.AnyAsync(u => u.UserName.ToLower() == request.UserName.ToLower().Trim()
                                                    || u.Email.ToLower() == request.Email.ToLower().Trim()))
                {
                    throw new Exception("Bu kullanıcı adı veya e-posta zaten kullanımda!");
                }

                var hashedPassword = HashPassword(request.Password);

                var newUser = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = hashedPassword
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return false;
            }
        }

        public async Task<UserDto?> ValidateUser(DataTO.LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            if (user == null) return null;


            var hashedInputPassword = HashPassword(request.Password);
            if (user.PasswordHash != hashedInputPassword)
                return null;


            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        internal async Task<bool> RegisterUser(Microsoft.AspNetCore.Identity.Data.RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        internal async Task ValidateUser(Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}