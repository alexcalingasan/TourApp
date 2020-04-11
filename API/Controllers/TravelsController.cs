using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Travels;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TravelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Travel>>> GetAll()
        {
            return await _mediator.Send(new List.Query());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> Get(int id)
        {
            return await _mediator.Send(new Details.Query{ TravelId = id });
        }

        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Update(Update.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command { TravelId = id });
        }
    }
}