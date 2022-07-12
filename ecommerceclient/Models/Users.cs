using System.ComponentModel.DataAnnotations;

namespace ecommerceclient.Models
{
    public class Users
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
