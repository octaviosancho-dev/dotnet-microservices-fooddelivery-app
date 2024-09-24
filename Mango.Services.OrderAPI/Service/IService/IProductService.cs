using FoodDelivery.Services.OrderAPI.Models.Dto;

namespace FoodDelivery.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
