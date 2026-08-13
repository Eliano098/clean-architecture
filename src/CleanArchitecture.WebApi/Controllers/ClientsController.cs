using CleanArchitecture.Application.Clients.Commands.CreateClient;
using CleanArchitecture.Application.Clients.Models;
using CleanArchitecture.Application.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetAll(CancellationToken cancellationToken)
    {
        var clients = await sender.Send(new GetClientsQuery(), cancellationToken);

        return Ok(clients);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateClientCommand command,
        CancellationToken cancellationToken)
    {
        var clientId = await sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = clientId }, clientId);
    }
}
