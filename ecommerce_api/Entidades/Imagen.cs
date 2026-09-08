using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Entidades
{
    public class Imagen:BaseEntity
    {
        [Unicode(false)]
        public required string Url { get; set; }
    }
}
