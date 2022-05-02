using Microsoft.AspNetCore.Mvc;

namespace teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<List<string>> Get()
        {
            return new List<string> { "a", "b", "c", "d" };
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<int> Get(int id)
        {
            var valor = new List<int> { 1,3, 4,6 };
            int retorno = 0;
            foreach (var item in valor)
            {

                if (item == id)
                    retorno = item; break;
            }
             return retorno;
        }
    }
}