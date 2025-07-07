using FlightCrew.Application.UseCases.PilotUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightCrew.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PilotController : Controller
    {
        private readonly IMediator _mediator;

        public PilotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllFlightsQueryRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdFlightsQueryRequest(id), cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
