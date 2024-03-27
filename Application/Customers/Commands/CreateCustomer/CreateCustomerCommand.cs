using Showcase.CleanArchitecture.Application.Abstractions.Messaging;
using Showcase.CleanArchitecture.Domain.Abstractions;
using Showcase.CleanArchitecture.Domain.ValueObjects;

namespace Showcase.CleanArchitecture.Application.Customers.Commands.CreateCustomer
{
    public sealed record CreateCustomerCommand(string Name, Document Document) : ICommand<Result>;
}