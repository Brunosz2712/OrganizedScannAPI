// Configuration/AuthorizeAttribute.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrganizedScannApi.Models;
using System;

namespace OrganizedScannAPI.Configuration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute(params UserRole[] roles) : Attribute, IAuthorizationFilter
    {
        private readonly UserRole[] _roles = roles;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User?)context.HttpContext.Items["User"];

            if (user == null)
            {
                // Não autenticado
                context.Result = new JsonResult(new { message = "Não autorizado" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            // Se roles foram especificados e o usuário não tem nenhum deles
            if (_roles.Length > 0 && Array.IndexOf(_roles, user.Role) == -1)
            {
                context.Result = new JsonResult(new { message = "Acesso proibido" })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}
