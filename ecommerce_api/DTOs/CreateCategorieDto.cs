using System.ComponentModel.DataAnnotations;

namespace ecommerce_api.DTOs
{
    public class CreateCategorieDto
    {
        [Required]
        public required string Name { get; set; }
        public IFormFile? Image { get; set; }
        public int Categorie_second_id { get; set; }
        public int Categorie_third_id { get; set; }
        [Required]
        public required int Position { get; set; }
    }
}
