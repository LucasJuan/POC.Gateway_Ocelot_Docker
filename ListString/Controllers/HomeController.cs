using Microsoft.AspNetCore.Mvc;

namespace ListString.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public async Task<List<string>> Get()
        {
            return new List<string> { "a", "b", "c", "d" };
        }
    }
}