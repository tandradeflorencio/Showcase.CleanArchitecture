using Showcase.CleanArchitecture.Domain.Exceptions.Base;

namespace Showcase.CleanArchitecture.Domain.Exceptions
{
    public class CustomerNotFoundException(Guid customerId) : NotFoundException($"The customer with ID {customerId} was not found.")
    {
    }
}