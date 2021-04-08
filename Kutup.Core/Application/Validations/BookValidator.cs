using FluentValidation;
using Kutup.Core.Domain.Entities;
using System;

namespace Kutup.Core.Application.Validations
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(b => b.Publisher)
                .MaximumLength(100);
            RuleFor(b => b.CoverImage)
                .MaximumLength(255);
            RuleFor(b => b.Page)
                .GreaterThan(5)
                .LessThan(2500);
            RuleFor(b => b.PublishingYear)
                .GreaterThan(1800)
                .LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(b => b.ISBN)
                .GreaterThanOrEqualTo(1000000000000)
                .LessThanOrEqualTo(9999999999999);

        }
    }
}
