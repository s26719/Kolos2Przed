using Microsoft.AspNetCore.Mvc;
using zad9NaCodeFirst.Exceptions;
using zad9NaCodeFirst.Services;

namespace zad9NaCodeFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClientAsync(int id)
    {
        try
        {
            await _clientService.DeleteClientAsync(id);
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