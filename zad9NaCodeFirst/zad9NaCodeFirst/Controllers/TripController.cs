using Microsoft.AspNetCore.Mvc;
using zad9NaCodeFirst.DTO_s;
using zad9NaCodeFirst.Exceptions;
using zad9NaCodeFirst.Services;

namespace zad9NaCodeFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTripDetailsAsync()
    {
        try
        {
           var trips =  await _tripService.GetTripDetailsAsync();
            return Ok(trips);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddClientToTripAsync(ClientInDto clientInDto)
    {
        try
        {
            await _tripService.AddClientToTripAsync(clientInDto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
}