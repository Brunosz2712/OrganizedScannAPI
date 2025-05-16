using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;  // <== para o [Authorize]
using OrganizedScannApi.Data;
using OrganizedScannApi.Models;
using System.Threading.Tasks;

namespace OrganizedScannApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "Admin")]  // Corrigido para string com role
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context) => _context = context;

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
