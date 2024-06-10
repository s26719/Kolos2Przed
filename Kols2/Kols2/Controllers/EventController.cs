using Kols2.Exceptions;
using Kols2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kols2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEventDetails(bool includeEndDate)
    {
        try
        {
            var events = await _eventService.GetEventDetailsAsync(includeEndDate);
            return Ok(events);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        try
        {
            await _eventService.DeleteEventAsync(id);
            return Ok();
        }
        catch (NotFoundExceptions e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
}