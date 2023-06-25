using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace superhero_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class superheroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<superhero>>> GetSuperHero()
        {
            return new List<superhero>
            {
                new superhero
                {
                    Name = "batman",
                    FirstName = "bruce",
                    LastName = "wayne",
                    Place = "gotham"
                }
            };
        }
    }
}
