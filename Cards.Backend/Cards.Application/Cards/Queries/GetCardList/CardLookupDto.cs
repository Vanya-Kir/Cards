using AutoMapper;
using Cards.Application.Common.Mappings;
using Cards.Domain;

namespace Cards.Application.Cards.Queries.GetCardList;

public class CardLookupDto : IMapWith<Card>
{
    public int Id { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Card, CardLookupDto>().
            ForMember(cardDto => cardDto.Id,
            opt => opt.MapFrom(card => card.Id)).
            ForMember(cardDto => cardDto.ImgUrl,
                opt => opt.MapFrom(card => card.ImgUrl)).
            ForMember(cardDto => cardDto.Details,
                opt => opt.MapFrom(card => card.Details)).
            ForMember(cardDto => cardDto.FirstTitle,
            opt => opt.MapFrom(card => card.FirstTitle)).
            ForMember(cardDto => cardDto.SecondTitle,
                opt => opt.MapFrom(card => card.SecondTitle));
    }
}