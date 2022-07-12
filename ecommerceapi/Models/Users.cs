using System.ComponentModel.DataAnnotations;

namespace ecommerceapi.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
