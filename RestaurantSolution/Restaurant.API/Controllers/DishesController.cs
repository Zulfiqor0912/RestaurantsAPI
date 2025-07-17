using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Command.CreateDish;

namespace Restaurant.API.Controllers;

[Route("api/restaurant/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand createDishCommand)
    {
        createDishCommand.RestaurantId = restaurantId;
        await mediator.Send(createDishCommand);
        return Created();
    }
}
