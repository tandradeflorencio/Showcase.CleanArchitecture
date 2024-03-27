using Showcase.CleanArchitecture.Domain.ValueObjects;

namespace Showcase.CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    public sealed record CreateCustomerRequest(string Name, Document Document);
}