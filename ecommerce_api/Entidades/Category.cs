namespace ecommerce_api.Entidades
{
    public class Category: BaseEntity
    {
        public required string Tipo { get; set; }
        public string? Talla { get; set; }
    }
}
