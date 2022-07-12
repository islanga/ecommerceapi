using System.ComponentModel.DataAnnotations;

namespace ecommerceclient.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
