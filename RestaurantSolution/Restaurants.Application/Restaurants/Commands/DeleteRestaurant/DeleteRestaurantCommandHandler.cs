using AutoMapper;
using MediatR;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant;

internal class DeleteRestaurantCommandHandler(
    IRestaurantsRepository restaurantsRepository,
    ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Idisi {request.Id} teng bo'lgan restoran o'chirildi");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        await restaurantsRepository.Delete(restaurant);
        return true;
    }
}
