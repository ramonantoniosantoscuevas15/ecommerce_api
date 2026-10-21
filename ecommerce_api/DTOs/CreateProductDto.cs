using System.ComponentModel.DataAnnotations;

namespace ecommerce_api.DTOs
{
    public class CreateProductDto
    {
        [Required]
        
        public  string Name { get; set; } = string.Empty;
        [Required]
        public  string Description { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage ="El precio debe ser mayor a 0")]
        public decimal Price { get; set; }
        [Required]
        public  IFormFile PictureUrl { get; set; } = null!;
        [Required]
        public  string Brand { get; set; } = string.Empty;
        [Required]
        public  string Type { get; set; } = string.Empty;
        [Range(1, int.MaxValue,ErrorMessage ="La cantidad en stock debe ser por lo menos 1")]
        public int QuantityInStock { get; set; }
    }
}
