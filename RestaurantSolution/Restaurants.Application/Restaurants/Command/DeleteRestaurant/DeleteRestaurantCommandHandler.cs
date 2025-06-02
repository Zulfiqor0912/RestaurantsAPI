using AutoMapper;
using MediatR;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant;

internal class DeleteRestaurantCommandHandler(
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository,
    ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Idisi {request.Id} teng bo'lgan restoran o'chirildi");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
            return false;

        await restaurantsRepository.Delete(restaurant);
        return true;
    }
}
