using AutoMapper;
using Cards.Application.Cards.Commands.UpdateCard;
using Cards.Application.Common.Mappings;

namespace Cards.WebAPI.Models;

public class UpdateCardDto : IMapWith<UpdateCardCommand>
{
    public int Id { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCardDto, UpdateCardCommand>().ForMember(cardCommand => cardCommand.Id,
            opt => opt.MapFrom(cartDto => cartDto.Id)).
            ForMember(cardCommand => cardCommand.FirstTitle,
            opt => opt.MapFrom(cartDto => cartDto.FirstTitle)).
            ForMember(cardCommand => cardCommand.SecondTitle,
            opt => opt.MapFrom(cartDto => cartDto.SecondTitle)).
            ForMember(cardCommand => cardCommand.Details,
            opt => opt.MapFrom(cartDto => cartDto.Details)).
            ForMember(cardCommand => cardCommand.ImgUrl,
            opt => opt.MapFrom(cartDto => cartDto.ImgUrl));

    }
}