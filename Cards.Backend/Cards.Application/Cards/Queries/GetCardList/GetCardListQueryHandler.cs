using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cards.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Cards.Queries.GetCardList;

public class GetCardListQueryHandler : IRequestHandler<GetCardListQuery, CardListVm>
{
    private readonly ICardsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCardListQueryHandler(ICardsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<CardListVm> Handle(GetCardListQuery request, CancellationToken cancellationToken)
    {
        var cardsQuery = await _dbContext.Cards.Where(card => card.UserId == request.UserId)
            .ProjectTo<CardLookupDto>(_mapper.ConfigurationProvider).
            ToListAsync(cancellationToken);
        return new CardListVm() { Cards = cardsQuery };
    }
}