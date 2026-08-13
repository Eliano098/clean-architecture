using CleanArchitecture.Application.Clients.Commands.CreateClient;
using CleanArchitecture.Application.Clients.Commands.UpdateClient;
using CleanArchitecture.Application.Clients.Models;
using CleanArchitecture.Application.Clients.Queries.GetClientById;
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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ClientDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var client = await sender.Send(new GetClientByIdQuery(id), cancellationToken);

        return client is null ? NotFound() : Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateClientCommand command,
        CancellationToken cancellationToken)
    {
        var clientId = await sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = clientId }, clientId);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateClientCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var updated = await sender.Send(command, cancellationToken);

        return updated ? NoContent() : NotFound();
    }
}
