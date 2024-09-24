using FoodDelivery.Services.RewardsAPI.Message;

namespace FoodDelivery.Services.RewardsAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}
