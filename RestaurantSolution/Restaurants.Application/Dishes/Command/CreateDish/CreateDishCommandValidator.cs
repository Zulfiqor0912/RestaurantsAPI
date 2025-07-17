using FluentValidation;

namespace Restaurants.Application.Dishes.Command.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Narx manfiy bo'lmasligi kerak");

            RuleFor(dish => dish.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Narx manfiy bo'lmasligi kerak");
        }
    }
}
