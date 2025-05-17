using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Barcha restoranlar olinyapti");
        var restaurants = await restaurantsRepository.GetAllAsync();
        return restaurants;
    }
}
