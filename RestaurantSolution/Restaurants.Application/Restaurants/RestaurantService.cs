using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantService> logger,
    IMapper mapper) : IRestaurantService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation($"Yangi restoran qo'shilmoqda: {dto}", dto);
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantsRepository.Create(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Barcha restoranlar olinyapti");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Ushbu {id} dagi restoran olinyapti");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

        return restaurantDto;
    }
}
