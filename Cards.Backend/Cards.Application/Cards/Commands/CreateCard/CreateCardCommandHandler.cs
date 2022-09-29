using Cards.Application.Interfaces;
using Cards.Domain;
using MediatR;

namespace Cards.Application.Cards.Commands.CreateCard;

public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, int>
{
    private readonly ICardsDbContext _dbContext;

    public CreateCardCommandHandler(ICardsDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<int> Handle(CreateCardCommand request,
        CancellationToken cancellationToken)
    {
        var card = new Card()
        {
            UserId = request.UserId,
            FirstTitle = request.FirstTitle,
            SecondTitle = request.SecondTitle,
            Details = request.Details,
            ImgUrl = request.ImgUrl,
        };
        await _dbContext.Cards.AddAsync(card, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return card.Id;
    }
}