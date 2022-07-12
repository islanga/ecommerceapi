using System.ComponentModel.DataAnnotations;

namespace ecommerceapi.Models
{
    public class Carts
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal TotalValue { get; set; }

        [Required]
        public int UserId { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Price { get; set; }

    }
}
