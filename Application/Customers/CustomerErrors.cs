using Showcase.CleanArchitecture.Domain.Abstractions;

namespace Showcase.CleanArchitecture.Application.Customers
{
    public static class CustomerErrors
    {
        public static readonly Error InvalidName = new("Customer.InvalidName", "Invalid name");
    }
}