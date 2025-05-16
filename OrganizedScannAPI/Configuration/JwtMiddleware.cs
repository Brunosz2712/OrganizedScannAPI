// Config/JwtMiddleware.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OrganizedScannApi.Config
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Sua lógica para validar token JWT aqui...

            await _next(context);
        }
    }
}
