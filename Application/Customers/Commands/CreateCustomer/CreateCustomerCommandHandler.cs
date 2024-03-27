using Showcase.CleanArchitecture.Application.Abstractions.Messaging;
using Showcase.CleanArchitecture.Domain.Abstractions;
using Showcase.CleanArchitecture.Domain.Entities;

namespace Showcase.CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, Result>
    {
        public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.Name, request.Document);

            await customerRepository.InsertAsync(customer);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}