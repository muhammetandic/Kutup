using FluentValidation;
using Kutup.Core.Domain.Entities;

namespace Kutup.Core.Application.Validations
{
    public class CatergoryValidator : AbstractValidator<Category>
    {
        public CatergoryValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}
