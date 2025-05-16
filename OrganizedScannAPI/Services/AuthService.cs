// Services/AuthService.cs
using Microsoft.AspNetCore.Identity;
using OrganizedScannApi.Data;
using OrganizedScannApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrganizedScannApi.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly TokenService _tokenService;

        public AuthService(
            ApplicationDbContext context,
            TokenService tokenService)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
            _tokenService = tokenService;
        }

        public async Task<Token> Login(Credentials credentials)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == credentials.Email);

            if (user == null)
            {
                throw new Exception("E-mail ou senha inválidos");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(
                user, user.Password, credentials.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("E-mail ou senha inválidos");
            }

            return _tokenService.GenerateToken(user);
        }
    }
}