using ecommerce_api.Entidades;
using ecommerce_api.Interfaces;

namespace ecommerce_api.Repositorios
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(AplicationBDContext context)
        {
            
        }
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
