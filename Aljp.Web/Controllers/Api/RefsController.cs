using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Refs")]
public class RefsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RefsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("ProductLines")]
    public async Task<IActionResult> GetProductLines()
    {
        var list = await _context.ProductLines.ToListAsync();
        return Ok(list);
    }
}