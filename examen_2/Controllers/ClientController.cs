using examen_2.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace examen_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController: ControllerBase
{
    private readonly   IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetAllClientByName(string name)
    {
        string nombreCovertido = name.ToUpper();
        Console.WriteLine(name);
        var  clients = await _clientService.GetClientsByContent(name);
        if (clients == null) return NotFound();
        return Ok(clients);
    }
}