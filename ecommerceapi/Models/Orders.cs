using System.ComponentModel.DataAnnotations;

namespace ecommerceapi.Models
{
    public class Orders
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
