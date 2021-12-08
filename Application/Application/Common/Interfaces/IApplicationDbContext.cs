using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }

    DbSet<Product> Products { get; }
    DbSet<Domain.Entities.Transaction> Transactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}