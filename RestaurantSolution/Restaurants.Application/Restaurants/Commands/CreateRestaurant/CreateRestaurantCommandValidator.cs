using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restoran nomi bo'sh bo'lmasligi kerak.")
            .Length(3, 100).WithMessage("Restoran nomi 3 dan 100 ta belgigacha bo'lishi kerak.");

        RuleFor(x => x.Category)
            .Must(validCategories.Contains)
            .WithMessage("Kategoriya xato. Iltimos to'g'ri kategoriyani tanlang");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Yaroqli elektron pochta manzilini kiriting.");

        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Iltimos, yaroqli postal kodni kiriting.");
    }
}
