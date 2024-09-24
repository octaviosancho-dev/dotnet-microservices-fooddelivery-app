using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
