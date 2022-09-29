using MediatR;

namespace Cards.Application.Cards.Commands.DeleteCard;

public class DeleteCardCommand : IRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
}