using MediatR;

namespace Cards.Application.Cards.Commands.UpdateCard;

public class UpdateCardCommand : IRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }   
}