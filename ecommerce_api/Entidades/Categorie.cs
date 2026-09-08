using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Entidades
{
    public class Categorie:BaseEntity
    {
        public required string Name { get; set; }
        public string? Icon { get; set; }
        [Unicode(false)]
        public string? Image { get; set; }
        public int Categorie_second_id { get; set; }
        public int Categorie_third_id { get; set; }
        public required int Position { get; set; }

    }
}
