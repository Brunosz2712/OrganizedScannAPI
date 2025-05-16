// Models/User.cs
namespace OrganizedScannApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        // ✅ Adicione esta propriedade:
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }
    }
}
