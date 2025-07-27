using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdRestaurant;

public class GetDishByIdRestaurantQuery(int dishId, int restaurantId) : IRequest<DishDto>
{
    public int DishId { get; } = dishId;
    public int RestaurantId { get; } = restaurantId;
}
