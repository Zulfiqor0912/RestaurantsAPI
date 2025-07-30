using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Command.CreateDish;
using Restaurants.Application.Dishes.Command.DeleteDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishByIdRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishForRestaurant;

namespace Restaurant.API.Controllers;

[Route("api/restaurant/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand createDishCommand)
    {
        var dishId = createDishCommand.RestaurantId = restaurantId;
        await mediator.Send(createDishCommand);
        return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdRestaurantQuery(dishId, restaurantId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishForRestaurant([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishForRestaurantCommand(restaurantId));
        return NoContent();
    }
}