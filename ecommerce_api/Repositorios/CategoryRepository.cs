using ecommerce_api.Entidades;
using ecommerce_api.Interfaces;

namespace ecommerce_api.Repositorios
{
    public class CategoryRepository : ICategorie
    {
        public void AddCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public bool CategorieExists(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie?> GetCategorieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Categorie>> GetCategoriesAsync(string? name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> GetNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }
    }
}
