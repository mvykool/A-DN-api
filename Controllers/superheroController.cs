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

        [HttpPost]
        public async Task<ActionResult<List<superhero>>> CreateSuperhero(superhero hero)
        {
            _context.Superheroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<superhero>>> UpdateSuperhero(superhero hero)
        {
            var dbHero = await _context.Superheroes.FindAsync(hero.Id);

            if (dbHero == null)
                return BadRequest("hero not found");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<superhero>>> DeleteHero(int id)
        {
            var dbHero = await _context.Superheroes.FindAsync(id);

            if (dbHero == null)
                return BadRequest("hero not found");

            _context.Superheroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }
    }
}
