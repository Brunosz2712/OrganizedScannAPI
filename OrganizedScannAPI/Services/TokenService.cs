using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using OrganizedScannApi.Models;

namespace OrganizedScannApi.Controllers.Services
{
    public class TokenService
    {
        public User? GetUserFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                var id = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (email == null || role == null || id == null || !int.TryParse(id, out int userId))
                    return null;

                return new User
                {
                    Id = userId,
                    Email = email,
                    Role = Enum.TryParse<UserRole>(role, out var userRole) ? userRole : UserRole.OPERATOR
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
