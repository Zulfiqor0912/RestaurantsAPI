using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; } = default!;
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];

    //public static RestaurantDto? FromEntity(Restaurant? restaurants)
    //{
    //    if (restaurants is null) return null;
    //    return new RestaurantDto()
    //    {
    //        Category = restaurants.Category,
    //        Description = restaurants.Description,
    //        Id = restaurants.Id,
    //        HasDelivery = restaurants.HasDelivery,
    //        Name = restaurants.Name,
    //        City = restaurants.Address?.City,
    //        Street = restaurants.Address?.Street,
    //        PostalCode = restaurants.Address?.PostalCode,
    //        Dishes = restaurants.Dishes.Select(DishDto.FromEntity).ToList(),
    //    };
    //}
}