using Microsoft.AspNetCore.Mvc;

/*
This controller uses a multi-version way of implementing methods , but it's not recommended if you're planning to scale your application as it gets messy real quick
*/
namespace VersionedAPI.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0",Deprecated = true)]
[ApiVersion("2.0")]
public class MultiVerController : ControllerBase
{
    // GET: api/<ValuesController>
    [HttpGet]
    [MapToApiVersion("1.0")]
    public IEnumerable<string> Get()
    {
        return new string[] { "first value", "second value" };
    }
    [HttpGet]
    [MapToApiVersion("2.0")]
    public IEnumerable<string> Getv2()
    {
        return new string[] { "v2 value1", "v2 value2" };
    }

}
