using FoodDelivery.Services.EmailAPI.Message;
using FoodDelivery.Services.EmailAPI.Models.Dto;

namespace FoodDelivery.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}
