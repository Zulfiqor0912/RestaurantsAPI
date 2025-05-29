using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreatRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    public CreatRestaurantDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restoran nomi bo'sh bo'lmasligi kerak.")
            .Length(3, 100).WithMessage("Restoran nomi 3 dan 100 ta belgigacha bo'lishi kerak.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Restoran tavsifi bo'sh bo'lmasligi kerak.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Tegishli toifani kiriting.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Yaroqli elektron pochta manzilini kiriting.");

        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Iltimos, yaroqli postal kodni kiriting.");
    }
}
