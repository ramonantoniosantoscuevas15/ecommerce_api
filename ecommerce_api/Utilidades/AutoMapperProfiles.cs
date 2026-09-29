using AutoMapper;
using ecommerce_api.DTOs;
using ecommerce_api.Entidades;

namespace ecommerce_api.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            ConfiguracionMappeoProductos();
        }


        private void ConfiguracionMappeoProductos()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(x => x.PictureUrl, opciones => opciones.Ignore());
            CreateMap<Product, ProductDto>();
        }

    }

}
