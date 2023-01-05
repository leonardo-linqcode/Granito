using Microsoft.AspNetCore.Mvc;

namespace Granito.Calculo.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ShowMeTheCodeController : Controller
    {
        [HttpGet("showmethecode")]
        public IActionResult GetGitHubLink()
        {
            return Ok("https://github.com/leonardo-linqcode/Granito");
        }
    }
}