using ecommerce_api.Entidades;
namespace ecommerce_api.Interfaces

{
    public interface ICategorie
    {
        Task<IReadOnlyList<Categorie>> GetCategoriesAsync(string?name);
        Task<Categorie?>GetCategorieByIdAsync(int id);
        Task<IReadOnlyList<string>> GetNameAsync();
        void AddCategorie(Categorie categorie);
        void UpdateCategorie(Categorie categorie);
        void DeleteCategorie(Categorie categorie);
        bool CategorieExists(int id);
        Task<bool> SaveChangesAsync();
    }
}
