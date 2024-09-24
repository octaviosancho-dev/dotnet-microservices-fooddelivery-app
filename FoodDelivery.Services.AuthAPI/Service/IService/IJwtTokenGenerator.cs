using FoodDelivery.Services.AuthAPI.Models;

namespace FoodDelivery.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
