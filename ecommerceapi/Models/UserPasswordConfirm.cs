using System.ComponentModel.DataAnnotations;

namespace ecommerceapi.Models
{
    public class UserPasswordConfirm
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Password do not match")]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
