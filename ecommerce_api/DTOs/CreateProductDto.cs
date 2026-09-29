using System.ComponentModel.DataAnnotations;

namespace ecommerce_api.DTOs
{
    public class CreateProductDto
    {
        
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required IFormFile PictureUrl { get; set; }
        public required string Brand { get; set; }
        public required string Type { get; set; }
        public int QuantityInStock { get; set; }
    }
}
