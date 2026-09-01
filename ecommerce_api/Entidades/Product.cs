using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Entidades
{
    public class Product : BaseEntity
    {
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public decimal Precio { get; set; }
        [Unicode(false)]
        public required string FotoUrl { get; set; }
        public required string Marca { get; set; }
    }
}
