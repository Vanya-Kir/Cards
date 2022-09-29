using MediatR;

namespace Cards.Application.Cards.Queries.GetCardDetails;

public class GetCardDetailsQuery : IRequest<CardDetailsVm>
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
}