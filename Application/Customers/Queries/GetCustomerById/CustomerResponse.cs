namespace Showcase.CleanArchitecture.Application.Customers.Queries.GetCustomerById
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}