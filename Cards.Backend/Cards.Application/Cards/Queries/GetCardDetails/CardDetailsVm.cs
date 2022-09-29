using AutoMapper;
using Cards.Application.Common.Mappings;
using Cards.Domain;

namespace Cards.Application.Cards.Queries.GetCardDetails;

public class CardDetailsVm : IMapWith<Card>
{
    public int Id { get; set; }
    public string? FirstTitle { get; set; }
    public string? SecondTitle { get; set; }
    public string? Details { get; set; }
    public string? ImgUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Card, CardDetailsVm>().
            ForMember(cardVm => cardVm.FirstTitle,
            opt => opt.MapFrom(card => card.FirstTitle)).
            ForMember(cardVm => cardVm.SecondTitle,
            opt => opt.MapFrom(card => card.SecondTitle)).
            ForMember(cardVm => cardVm.Details,
            opt => opt.MapFrom(card => card.Details)).
            ForMember(cardVm => cardVm.ImgUrl,
            opt => opt.MapFrom(card => card.ImgUrl));

    }
}