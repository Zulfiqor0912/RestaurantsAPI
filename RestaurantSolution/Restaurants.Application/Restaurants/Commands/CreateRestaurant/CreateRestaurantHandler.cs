using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant;

public class CreateRestaurantHandler(
    ILogger<CreateRestaurantHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Yangi restoran qo'shilmoqda: {request}", request);

        var restaurant = mapper.Map<Restaurant>(request);

        int id = await restaurantsRepository.Create(restaurant);

        return id;
    }
}