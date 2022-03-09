using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "MiniBids")]
public class MiniBidsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MiniBidsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        var list = await _context.MiniBids.ToListAsync(token);
        return Ok(list);
    }

    [HttpGet]
    [Route("{id:int}", Name = "GetMiniBidById")]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _context.MiniBids.FindAsync(new object?[] { id }, cancellationToken: token);
        return Ok(entity);
    }

    [HttpPost]
    [Route("", Name = "CreateMiniBid")]
    public async Task<ActionResult> Post([FromBody] CreateMiniBid command, CancellationToken token = new())
    {
        var entity = new Domain.Entities.MiniBid(command.ProjectTitle, command.DistrictName, command.Description);
        entity.UpdateDueDate(command.DueDate);

        await _context.MiniBids.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);

        var response = new CreateMiniResponse
        {
            Id = entity.Id,
            ProjectTitle = entity.ProjectTitle,
            DistrictName = entity.DistrictName,
            Description = entity.Description,
            DueDate = entity.DueDate
        };

        return new CreatedAtRouteResult("GetMiniBidById", new { id = entity.Id }, response);
    }

    [HttpPut]
    [Route("", Name = "UpdateMiniBid")]
    public async Task<ActionResult> Put([FromBody] UpdateMiniBid command, CancellationToken token = new())
    {
        var entity = await _context.MiniBids.FindAsync(new object?[] { command.Id }, cancellationToken: token);

        if (entity == null) return NotFound(command);

        entity.Update(command.ProjectTitle, command.DistrictName, command.Description);
        entity.UpdateDueDate(command.DueDate);

        await _context.SaveChangesAsync(token);

        return Ok();
    }

    public record UpdateMiniBid(int Id, string ProjectTitle, string DistrictName, string Description, DateTime DueDate);

    public record CreateMiniBid(string ProjectTitle, string DistrictName, string Description, DateTime DueDate);

    private class CreateMiniResponse
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}