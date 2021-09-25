using System.ComponentModel.DataAnnotations;

namespace DatingApp.DatingApp.API.DTOs
{
    public class Registerdto
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}