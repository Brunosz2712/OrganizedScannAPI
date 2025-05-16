// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Models;
using OrganizedScannApi.Services;
using System;
using System.Threading.Tasks;

namespace OrganizedScannApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromBody] Credentials credentials)
        {
            try
            {
                var token = await _authService.Login(credentials);
                return token;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
