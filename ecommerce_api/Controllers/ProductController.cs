using AutoMapper;
using AutoMapper.QueryableExtensions;
using ecommerce_api.DTOs;
using ecommerce_api.Entidades;
using ecommerce_api.Interfaces;
using ecommerce_api.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly AplicationBDContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ILocalFileStorage localFileStorage;
        private const string cacheTag = "products";
        private readonly string contenedor = "products";

        public ProductController(AplicationBDContext context,IMapper mapper,IOutputCacheStore outputCacheStore,
            ILocalFileStorage localFileStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
            this.localFileStorage = localFileStorage;
        }
        [HttpGet("{id:int}",Name = "ObtenerProductoPorId")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await context.Products.ProjectTo
                <ProductDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateProductDto createProductDto)
        {
            var product = mapper.Map<Product>(createProductDto);
            if(createProductDto.PictureUrl is not null)
            {
                var url = await localFileStorage.Almacenar(contenedor, createProductDto.PictureUrl);
                product.PictureUrl = url;
            }
            context.Add(product);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return CreatedAtRoute("ObtenerProductoPorId", new { id = product.Id }, product);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] CreateProductDto createProductDto)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            product = mapper.Map(createProductDto, product);

            if(createProductDto.PictureUrl is not null)
            {
                product.PictureUrl = await localFileStorage.Editar(contenedor, product.PictureUrl, createProductDto.PictureUrl);
            }
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteproduct = await context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
            if(deleteproduct == 0)
            {
                return NotFound();
            }
            
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return NoContent();

        }
        [HttpGet("Type")]
        public async Task<ActionResult<List<string>>> GetTypes()
        {
            return await context.Products.Select(p => p.Type).Distinct().ToListAsync();
        }
        [HttpGet("Brand")]
        public async Task<ActionResult<List<string>>> GetBrands()
        {
            return await context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        }

        [HttpGet("Filter")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<IReadOnlyList<Product>> GetProducts([FromQuery] string? brand,string? type,string? sort)
        {
            var queryable = context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            
                queryable = queryable.Where(p => p.Brand == brand);
            if (!string.IsNullOrWhiteSpace(type))
                queryable = queryable.Where(p => p.Type == type);
            
                queryable = sort switch
                {
                    "priceAsc" => queryable.OrderBy(p => p.Price),
                    "priceDesc" => queryable.OrderByDescending(p => p.Price),
                    _ => queryable.OrderBy(p => p.Name)

                };

            

            return await queryable.ToListAsync();

        }









    }
}
