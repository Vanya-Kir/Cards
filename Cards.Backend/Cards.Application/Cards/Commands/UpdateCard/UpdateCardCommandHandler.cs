using Cards.Application.Common.Exceptions;
using Cards.Application.Interfaces;
using Cards.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Cards.Commands.UpdateCard;

public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
{
    private readonly ICardsDbContext _dbContext;

    public UpdateCardCommandHandler(ICardsDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Cards.FirstOrDefaultAsync(card =>
            card.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Card), request.Id);
        }

        entity.FirstTitle = request.FirstTitle;
        entity.SecondTitle = request.SecondTitle;
        entity.Details = request.Details;
        entity.ImgUrl = request.ImgUrl;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}