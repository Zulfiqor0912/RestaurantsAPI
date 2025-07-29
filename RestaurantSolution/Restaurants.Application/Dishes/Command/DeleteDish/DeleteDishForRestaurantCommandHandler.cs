using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Command.DeleteDish;

public class DeleteDishForRestaurantCommandHandler(ILogger<DeleteDishForRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishRepository dishRepository) : IRequestHandler<DeleteDishForRestaurantCommand>
{
    public async Task Handle(DeleteDishForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        await dishRepository.Delete(restaurant.Dishes);
    }
}
