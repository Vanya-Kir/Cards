using Cards.Application.Common.Exceptions;
using Cards.Application.Interfaces;
using Cards.Domain;
using MediatR;

namespace Cards.Application.Cards.Commands.DeleteCard;

public class DeleteCardCommandHadler : IRequestHandler<DeleteCardCommand>
{
    private readonly ICardsDbContext _dbContext;

    public DeleteCardCommandHadler(ICardsDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Cards.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Card), request.Id);
        }
        _dbContext.Cards.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
