using Dream_House.Data;
using Dream_House.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dream_House.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<(bool success, string firstName, string lastName)> AuthenticateUserAsync(string email, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                    return false;

                if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                    return false;

                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    HashPassword = HashPassword(model.Password),
                    RoleId = model.RoleId,
                    RegistrationDate = DateTime.Now
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }

        public async Task<(bool success, string firstName, string lastName)> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                    return (false, null, null);

                return user.HashPassword == HashPassword(password)
                    ? (true, user.Name, user.Surname)
                    : (false, null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка аутентификации: {ex.Message}");
                return (false, null, null);
            }
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}