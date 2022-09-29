using MediatR;
namespace Cards.Application.Cards.Commands.CreateCard;

public class CreateCardCommand : IRequest<int>
{
    public Guid UserId { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }    
}