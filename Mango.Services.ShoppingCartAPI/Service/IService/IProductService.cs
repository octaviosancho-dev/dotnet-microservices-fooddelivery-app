using FoodDelivery.Services.ShoppingCartAPI.Models.Dto;

namespace FoodDelivery.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
