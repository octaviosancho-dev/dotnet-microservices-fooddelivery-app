using AutoMapper;
using FoodDelivery.Services.ShoppingCartAPI.Models;
using FoodDelivery.Services.ShoppingCartAPI.Models.Dto;

namespace FoodDelivery.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
