using APBD_Tutorial8.Application.Queries.TripQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial8.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TripsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        return Ok(await _mediator.Send(new GetTripsQuery()));
    }
}