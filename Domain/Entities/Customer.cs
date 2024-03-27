using Showcase.CleanArchitecture.Domain.ValueObjects;

namespace Showcase.CleanArchitecture.Domain.Entities
{
    public class Customer
    {
        private Customer()
        {
        }

        public CustomerId Id { get; private set; }
        public string Name { get; private set; }

        public Document Document { get; private set; }

        public static Customer Create(string name, Document document)
        {
            return new Customer
            {
                Id = new CustomerId(Guid.NewGuid()),
                Name = name,
                Document = document
            };
        }
    }
}