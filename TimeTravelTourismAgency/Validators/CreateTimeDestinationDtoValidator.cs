using FluentValidation;
using TimeTravelTourismAgency.DTOs;

namespace TimeTravelTourismAgency.Validators;

public class CreateTimeDestinationDtoValidator : AbstractValidator<CreateTimeDestinationDto>
{
    public CreateTimeDestinationDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        RuleFor(x => x.TargetYear)
            .NotEmpty().WithMessage("Hedef yıl bilgisi zorunludur (Örn: 1500, MÖ 2560).");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Kapasite en az 1 kişi olmalıdır.");

        RuleFor(x => x.DangerLevel)
            .InclusiveBetween(1, 5).WithMessage("Tehlike seviyesi 1 ile 5 arasında olmalıdır.");
    }
}