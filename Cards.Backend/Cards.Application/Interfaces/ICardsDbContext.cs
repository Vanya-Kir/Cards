using Cards.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Interfaces;

public interface ICardsDbContext
{
    DbSet<Card> Cards { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}