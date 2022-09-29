using AutoMapper;
using Cards.Application.Common.Exceptions;
using Cards.Application.Interfaces;
using Cards.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Cards.Queries.GetCardDetails;

public class GetCardDetailsQueryHandler : IRequestHandler<GetCardDetailsQuery, CardDetailsVm>
{
    private readonly ICardsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCardDetailsQueryHandler(ICardsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CardDetailsVm> Handle(GetCardDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Cards.FirstOrDefaultAsync(card => card.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Card), request.Id);
        }

        return _mapper.Map<CardDetailsVm>(entity);
    }
}