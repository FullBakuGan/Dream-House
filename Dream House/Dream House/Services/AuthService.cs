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
        Task<(bool success, string firstName, string lastName, int roleId)> AuthenticateUserAsync(string email, string password);
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
                var userExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
                if (userExists)
                {
                    return false; // Пользователь с таким email уже существует
                }

                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    DateOfBirth = DateTime.SpecifyKind(model.DateOfBirth, DateTimeKind.Unspecified), // Устанавливаем Kind=Unspecified
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    HashPassword = HashPassword(model.Password),
                    RoleId = model.RoleId,
                    RegistrationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified) // Устанавливаем Kind=Unspecified
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }

        public async Task<(bool success, string firstName, string lastName, int roleId)> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                    return (false, null, null, 1);

                return user.HashPassword == HashPassword(password)
                    ? (true, user.Name, user.Surname, user.RoleId)
                    : (false, null, null, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка аутентификации: {ex.Message}");
                return (false, null, null, 1);
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