using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.CleanArchitecture.Domain.Entities;

namespace Showcase.CleanArchitecture.Infrastructure.Configuration
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Id)
                .HasConversion(customerId => customerId.Id,
                value => new Domain.ValueObjects.CustomerId(value));

            builder.Property(customer => customer.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(customer => customer.Document)
                .HasMaxLength(20)
                .HasConversion(document => document.Number,
                value => new Domain.ValueObjects.Document(value));
        }
    }
}