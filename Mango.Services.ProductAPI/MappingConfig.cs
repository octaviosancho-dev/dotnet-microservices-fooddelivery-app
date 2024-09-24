using AutoMapper;
using FoodDelivery.Services.ProductAPI.Models;
using FoodDelivery.Services.ProductAPI.Models.Dto;

namespace FoodDelivery.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
