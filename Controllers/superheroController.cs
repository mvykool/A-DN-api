using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using superhero_api.Data;

namespace superhero_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class superheroController : ControllerBase
    {
        private readonly DataContext _context;
        
        public superheroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<superhero>>> GetSuperHero()
        {
            return Ok(await _context.Superheroes.ToListAsync());
        }
    }
}
