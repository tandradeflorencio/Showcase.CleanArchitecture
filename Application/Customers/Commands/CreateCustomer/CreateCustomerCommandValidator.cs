using FluentValidation;

namespace Showcase.CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Document).NotNull()
                .NotEmpty();
        }
    }
}