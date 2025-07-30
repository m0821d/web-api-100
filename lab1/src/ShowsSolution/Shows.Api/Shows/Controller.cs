using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;
namespace Shows.Api.Shows;

public class Controller(IDocumentSession session) : ControllerBase
{
    //this methodshould implement POST to get a show
    [HttpPost("/api/shows")]
    public async Task<ActionResult> AddAShow(
       [FromBody] AddShowRequest request,
       //[FromServices] IValidator<CreateShowRequest> validator,
       CancellationToken cancellationToken)
    {
        //var validationResults = await validator.ValidateAsync(request);
        //if (!validationResults.IsValid)
        //{
        //    return BadRequest(validationResults);
        //}

        var response = new AddShowResponse(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StreamingService,
            DateTimeOffset.UtcNow
            );
        session.Store(response);
        await session.SaveChangesAsync();
        return Ok(response);
    }

    [HttpGet("/api/shows/{id:guid}")]
    public async Task<ActionResult> GetShowByIdAsync(Guid id, CancellationToken token)
    {
        // look that thing up in the database.
        var response = await session
            .Query<AddShowResponse>()
            .Where(v => v.Id == id)
            .SingleOrDefaultAsync();

        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }

    [HttpGet("/api/shows")]
    public async Task<ActionResult> GetAllShowsAsync(CancellationToken token)
    {
        var response = await session.Query<AddShowResponse>()
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync(token);

        return Ok(response);
    }

    public record AddShowRequest
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string StreamingService { get; init; }  =string.Empty;

    }

    public record AddShowResponse(
        Guid Id, 
        string Name, string Description, 
        string StreamingService, 
        DateTimeOffset CreatedAt
        );
}


