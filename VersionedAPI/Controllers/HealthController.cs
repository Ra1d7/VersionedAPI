using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersionedAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral] //Meaning this whole controller will be avaliable in every single api version
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping() 
        {
            return Ok("Everything seems fine!");
        }
    }
}
