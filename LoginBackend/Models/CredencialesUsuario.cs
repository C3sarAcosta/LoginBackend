using System.ComponentModel.DataAnnotations;

namespace LoginBackend.Models
{
    public class CredencialesUsuario
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
