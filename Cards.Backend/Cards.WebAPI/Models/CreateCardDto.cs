using AutoMapper;
using Cards.Application.Cards.Commands.CreateCard;
using Cards.Application.Common.Mappings;

namespace Cards.WebAPI.Models;

public class CreateCardDto : IMapWith<CreateCardCommand>
{
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCardDto, CreateCardCommand>().
            ForMember(noteCommand => noteCommand.FirstTitle,
            opt => opt.MapFrom(noteDto => noteDto.FirstTitle)).
            ForMember(noteCommand => noteCommand.SecondTitle,
            opt => opt.MapFrom(noteDto => noteDto.SecondTitle)).
            ForMember(noteCommand => noteCommand.Details,
            opt => opt.MapFrom(noteDto => noteDto.Details)).
            ForMember(noteCommand => noteCommand.ImgUrl,
            opt => opt.MapFrom(noteDto => noteDto.ImgUrl));

    }
}