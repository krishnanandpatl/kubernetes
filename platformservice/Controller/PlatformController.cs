using Microsoft.AspNetCore.Mvc;

namespace platformservice.Controller
{
    [ApiController]
    [Route("api/platform")]
    public class PlatformController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Platform()
        {
            return Ok("hello");
        }
    }
}