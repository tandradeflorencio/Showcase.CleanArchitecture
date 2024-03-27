using Microsoft.EntityFrameworkCore;
using Showcase.CleanArchitecture.Domain.Abstractions;

namespace Showcase.CleanArchitecture.Infrastructure
{
    public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}