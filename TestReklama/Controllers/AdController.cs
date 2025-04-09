using Microsoft.AspNetCore.Mvc;
using TestReklama.Services;

namespace TestReklama.Controllers
{
    public class AdController : Controller
    {
        private readonly AdPlatformService _service;

        public AdController(AdPlatformService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromBody] string[] lines)
        {
            _service.LoadFromFile(lines);
            return Ok("Upload successful");
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Location is required");

            var result = _service.FindPlatforms(location);
            return Ok(result);
        }
    }
}
