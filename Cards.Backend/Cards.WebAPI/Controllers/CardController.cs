using System.Runtime.CompilerServices;
using AutoMapper;
using Cards.Application.Cards.Commands.CreateCard;
using Cards.Application.Cards.Commands.DeleteCard;
using Cards.Application.Cards.Commands.UpdateCard;
using Cards.Application.Cards.Queries.GetCardDetails;
using Cards.Application.Cards.Queries.GetCardList;
using Cards.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cards.WebAPI.Controllers;

[Route("api/[controller]")]
public class CardController : BaseController
{
    private readonly IMapper _mapper;

    public CardController(IMapper mapper) => _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<CardListVm>> GetAll()
    {
        var query = new GetCardListQuery()
        {
            UserId = UserId,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CardDetailsVm>> Get(int id)
    {
        var query = new GetCardDetailsQuery()
        {
            UserId = UserId,
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCardDto createCardDto)
    {
        var command = _mapper.Map<CreateCardCommand>(createCardDto);
        command.UserId = UserId;
        var carId = await Mediator.Send(command);
        return Ok(carId);
    }
    
    [HttpPut]
    public async Task<ActionResult<int>> Create([FromBody] UpdateCardDto updateCardDto)
    {
        var command = _mapper.Map<UpdateCardCommand>(updateCardDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<ActionResult<int>> Delete(int id)
    {
        var command = new DeleteCardCommand()
        {
            Id = id,
            UserId = UserId
        };
        await Mediator.Send(command);
        return NoContent();
    }
}