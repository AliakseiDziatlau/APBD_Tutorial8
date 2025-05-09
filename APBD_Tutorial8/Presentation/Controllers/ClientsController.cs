using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Application.Queries.ClientQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial8.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}/trips")]
    public async Task<IActionResult> GetClient(int id)
    {
        return Ok(await _mediator.Send(new GetClientsTripsByIdQuery() { ClientId = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand command)
    {
        return StatusCode(201, new { Id = await _mediator.Send(command) });
    }

    [HttpPut("{id}/trips/{tripId}")]
    public async Task<IActionResult> RegisterClientForATrip(int id, int tripId)
    {
        var result = await _mediator.Send(new RegisterClientForATripCommand() { ClientId = id, TripId = tripId });
        
        if (result.Success)
            return Ok(new { message = result.Message });

        return BadRequest(new { message = result.Message });
    }

    [HttpDelete("{id}/trips/{tripId}")]
    public async Task<IActionResult> DeleteClientForATrip(int id, int tripId)
    {
        var result = await _mediator.Send(new DeleteClientForATripCommand() { ClientId = id, TripId = tripId });
        
        if (result.Success)
            return NoContent();
        
        return BadRequest(new { message = result.Message });
    }
}