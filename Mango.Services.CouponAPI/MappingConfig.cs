using AutoMapper;
using FoodDelivery.Services.CouponAPI.Models;
using FoodDelivery.Services.CouponAPI.Models.Dto;

namespace FoodDelivery.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
