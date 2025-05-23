using AutoMapper;

namespace Restaurants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dishes, DishDto>()
            .Map
    }
}
