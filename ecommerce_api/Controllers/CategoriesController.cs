using ecommerce_api.Entidades;
using ecommerce_api.Interfaces;
using ecommerce_api.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(IGenericRepository<Categorie> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categorie>>> GetCategories(string? name)
        {
            var spec = new CategorySpecification(name);
            var category = await repo.ListAsync(spec);
            return Ok(category);

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
            var category = await repo.GetByIdAsync(id);
            if (category == null) return NotFound();
            return category;
        }
        [HttpPost]
        public async Task<ActionResult<Categorie>> CreateCategory(Categorie categorie)
        {
            repo.Add(categorie);

            if (await repo.SaveAllAsync())
            {
                return CreatedAtAction("GetCategorie", new { id = categorie.Id }, categorie);
            }
            return BadRequest("Problemas al Crear una Categoria");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int id, Categorie categorie)
        {
            if(categorie.Id != id || !CategoryExists(id) )
                return BadRequest("Problemas al Actualizar la Categoria");
            repo.Update(categorie);

            if(await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problemas Actualizando esta categoria");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await repo.GetByIdAsync(id);
            if (category == null) return NotFound();
            repo.Remove(category);
            if(await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problemas al Eliminar la Categoria");
        }
        private bool CategoryExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
