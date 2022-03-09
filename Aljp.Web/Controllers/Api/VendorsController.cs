using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Vendors")]
public class VendorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VendorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Route("")]
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        var list = await _context.Vendors.ToListAsync(cancellationToken: token);
        return Ok(list);
    }

    [HttpGet]
    [Route("{id:int}", Name = "GetVendorById")]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _context.Vendors.FindAsync(new object?[] { id }, cancellationToken: token);
        return Ok(entity);
    }

    [HttpPost]
    [Route("", Name = "CreateVendor")]
    public async Task<ActionResult> Post([FromBody] CreateVendor command, CancellationToken token = new())
    {
        var entity = new Domain.Entities.Vendor(command.CompanyName, command.SpinNumber);
        entity.UpdateAddress(command.Street, command.City, command.State, command.PostalCode);

        _context.Vendors.Add(entity);
        await _context.SaveChangesAsync(token);

        var response = new CreateVendorResponse
        {
            Id = entity.Id,
            CompanyName = entity.CompanyName,
            CompanyWebsiteUrl = entity.CompanyWebsiteUrl,
            SpinNumber = entity.SpinNumber,
            PhoneNumber = entity.PhoneNumber,
            Street = entity.Street,
            City = entity.City,
            State = entity.State,
            PostalCode = entity.PostalCode
        };

        return new CreatedAtRouteResult("GetVendorById", new { id = entity.Id }, response);
    }

    [HttpPut]
    [Route("", Name = "UpdateVendor")]
    public async Task<ActionResult> Put([FromBody] UpdateVendor command, CancellationToken token = new ())
    {
        var entity = await _context.Vendors.FindAsync(new object?[] { command.Id }, cancellationToken: token);

        if (entity == null) return NotFound(command);

        entity.UpdateCompany(command.CompanyName, command.CompanyWebsiteUrl, command.SpinNumber);
        entity.UpdateAddress(command.Street, command.City, command.State, command.PostalCode);
        entity.UpdatePhone(command.PhoneNumber);

        await _context.SaveChangesAsync(token);

        return Ok();
    }
    
    public record UpdateVendor(int Id, string CompanyName, string CompanyWebsiteUrl, string SpinNumber,
        string PhoneNumber, string Street, string City, string State, string PostalCode);

    public record CreateVendor(string CompanyName, string CompanyWebsiteUrl, string SpinNumber,
        string PhoneNumber, string Street, string City, string State, string PostalCode);

    private class CreateVendorResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyWebsiteUrl { get; set; } = string.Empty;
        public string SpinNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}

