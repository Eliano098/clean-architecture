using CleanArchitecture.Application.Clients.Commands.CreateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateClientCommand command,
        CancellationToken cancellationToken)
    {
        var clientId = await sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = clientId }, clientId);
    }
}
