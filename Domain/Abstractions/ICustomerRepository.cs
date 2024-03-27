using Showcase.CleanArchitecture.Domain.Entities;

namespace Showcase.CleanArchitecture.Domain.Abstractions
{
    public interface ICustomerRepository
    {
        Task InsertAsync(Customer customer);
    }
}