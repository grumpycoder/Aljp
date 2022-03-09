using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Contacts")]
public class ContactsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContactsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        var list = await _context.Contacts.ToListAsync(token);
        return Ok(list);
    }

    [HttpGet]
    [Route("{id:int}", Name = "GetContactById")]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _context.Contacts.FindAsync(new object?[] { id }, cancellationToken: token);
        return Ok(entity);
    }

    [HttpPost]
    [Route("", Name = "CreateContact")]
    public async Task<ActionResult> Post([FromBody] CreateContact command, CancellationToken token = new())
    {
        var entity =
            new Domain.Entities.Contact(command.Firstname, command.Lastname, command.Title, command.EmailAddress);
        entity.UpdatePhone(command.BusinessPhone, command.MobilePhone);

        _context.Contacts.Add(entity);
        await _context.SaveChangesAsync(token);

        var response = new CreateContactResponse
        {
            Id = entity.Id,
            Firstname = entity.Firstname,
            Lastname = entity.Lastname,
            EmailAddress = entity.EmailAddress,
            Title = entity.Title,
            BusinessPhone = entity.BusinessPhone,
            MobilePhone = entity.MobilePhone
        };

        return new CreatedAtRouteResult("GetContactById", new { id = entity.Id }, response);
    }

    [HttpPut]
    [Route("", Name = "UpdateContact")]
    public async Task<ActionResult> Put([FromBody] UpdateContact command, CancellationToken token = new())
    {
        var entity = await _context.Contacts.FindAsync(new object?[] { command.Id }, cancellationToken: token);

        if (entity == null) return NotFound(command);

        entity.Update(command.Firstname, command.Lastname, command.Title, command.EmailAddress);
        entity.UpdatePhone(command.BusinessPhone, command.MobilePhone);

        await _context.SaveChangesAsync(token);

        return Ok();
    }

    public record UpdateContact(int Id, string Firstname, string Lastname, string Title, string EmailAddress,
        string BusinessPhone, string MobilePhone);

    public record CreateContact(string Firstname, string Lastname, string Title, string EmailAddress,
        string BusinessPhone, string MobilePhone);

    private class CreateContactResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string BusinessPhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
    }
}