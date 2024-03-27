using Showcase.CleanArchitecture.Application.Abstractions.Messaging;

namespace Showcase.CleanArchitecture.Application.Customers.Queries.GetCustomerById
{
    public sealed record GetCustomerByIdQuery(Guid CustomerId) : IQuery<CustomerResponse>;
}