using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Contracts")]
public class ContractsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContractsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        var list = await _context.Contracts.ToListAsync(token);
        return Ok(list);
    }

    [HttpGet]
    [Route("{id:int}", Name = "GetContractById")]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _context.Contracts.FindAsync(new object?[] { id }, cancellationToken: token);
        return Ok(entity);
    }

    [HttpPost]
    [Route("", Name = "CreateContract")]
    public async Task<ActionResult> Post([FromBody] CreateContract command, CancellationToken token = new())
    {
        var entity = new Domain.Entities.Contract(command.StateContractId, command.AwardDate, command.StartDate,
            command.ContractExpireDate, command.IsoExpirationDate, command.Discount, command.State470Number);

        _context.Contracts.Add(entity);
        await _context.SaveChangesAsync(token);

        var response = new CreateContractResponse
        {
            Id = entity.Id,
            StateContractId = entity.StateContractId,
            AwardDate = entity.AwardDate,
            StartDate = entity.StartDate,
            ContractExpireDate = entity.ContractExpireDate,
            Discount = entity.Discount,
            IsoExpirationDate = entity.IsoExpirationDate,
            State470Number = entity.State470Number
        };

        return new CreatedAtRouteResult("GetContractById", new { id = entity.Id }, response);
    }

    [HttpPut]
    [Route("", Name = "UpdateContract")]
    public async Task<ActionResult> Put([FromBody] UpdateContract command, CancellationToken token = new())
    {
        var entity = await _context.Contracts.FindAsync(new object?[] { command.Id }, cancellationToken: token);

        if (entity == null) return NotFound(command);

        entity.Update(command.StateContractId, command.AwardDate, command.StartDate, command.ContractExpireDate,
            command.IsoExpirationDate, command.Discount, command.State470Number);

        await _context.SaveChangesAsync(token);

        return Ok();
    }

    public record UpdateContract(int Id, string StateContractId, DateOnly? AwardDate, DateOnly? StartDate,
        DateOnly? ContractExpireDate,
        DateOnly? IsoExpirationDate, double? Discount, string State470Number);

    public record CreateContract(string StateContractId, DateOnly? AwardDate, DateOnly? StartDate,
        DateOnly? ContractExpireDate,
        DateOnly? IsoExpirationDate, double? Discount, string State470Number);

    private class CreateContractResponse
    {
        public int Id { get; set; }
        public string StateContractId { get; set; } = string.Empty;
        public DateOnly? AwardDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? ContractExpireDate { get; set; }
        public DateOnly? IsoExpirationDate { get; set; }
        public double? Discount { get; set; }
        public string State470Number { get; set; } = string.Empty;
    }
}