using FluentValidation;
using Kutup.Core.Domain.Entities;

namespace Kutup.Core.Application.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
