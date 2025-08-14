using Microsoft.AspNetCore.Identity;

namespace Restaurants.Infrastructure.Seeders
{
    public interface IRestaurantSeeders
    {
        Task Seed();

        //IEnumerable<IdentityRole> GetRoles();
    }
}