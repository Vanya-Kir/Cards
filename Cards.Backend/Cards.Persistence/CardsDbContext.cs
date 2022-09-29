using Cards.Application.Interfaces;
using Cards.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cards.Persistence;

public class CardsDbContext : DbContext, ICardsDbContext
{
    public CardsDbContext(DbContextOptions<CardsDbContext> options)
        : base(options)
    {
    }
    public DbSet<Card> Cards { get; set; }
}