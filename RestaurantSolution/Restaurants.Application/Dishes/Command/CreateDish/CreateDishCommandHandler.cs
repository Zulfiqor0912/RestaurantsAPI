using MediatR;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Command.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateDishCommand>
{

    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Yangi idish yaratildi: ", request);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaturantId);
        if (restaurant == null) throw new DirectoryNotFoundException(nameof(Restaurant), request.RestaturantId.ToString());
    }
}
