using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Barcha restoranlar olinyapti");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);

        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Ushbu {id} dagi restoran olinyapti");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;
    }
}
