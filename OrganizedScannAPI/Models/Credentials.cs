// Models/Credentials.cs
using System.ComponentModel.DataAnnotations;

namespace OrganizedScannApi.Models
{
    public class Credentials
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; } = null!;
    }
}