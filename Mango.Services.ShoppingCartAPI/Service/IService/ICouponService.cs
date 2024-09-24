using FoodDelivery.Services.ShoppingCartAPI.Models.Dto;

namespace FoodDelivery.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
