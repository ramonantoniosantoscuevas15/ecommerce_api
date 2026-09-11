using ecommerce_api.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api
{
    public class AplicationBDContext : IdentityDbContext
    {
        public AplicationBDContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            



        }
        public DbSet<Categorie> Categories { get; set; }
    }
}
