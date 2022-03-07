using Microsoft.AspNetCore.Mvc;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Vendors")]
public class VendorsController: ControllerBase
{
    
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        return Ok();
    }

}