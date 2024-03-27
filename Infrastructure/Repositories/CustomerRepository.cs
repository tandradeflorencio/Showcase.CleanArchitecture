using Showcase.CleanArchitecture.Domain.Abstractions;
using Showcase.CleanArchitecture.Domain.Entities;

namespace Showcase.CleanArchitecture.Infrastructure.Repositories
{
    public sealed class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
    {
        public async Task InsertAsync(Customer customer) =>
            await context.Set<Customer>().AddAsync(customer);
    }
}