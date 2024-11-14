using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MoroccoCities.Models;

namespace MoroccoCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StreetController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Street
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Street>>> GetStreets()
        {
            return await _context.Street.Include(s => s.City).ToListAsync();
        }

        // GET: api/Street/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Street>> GetStreet(int id)
        {
            var street = await _context.Street.Include(s => s.City)
                                               .FirstOrDefaultAsync(s => s.Id == id);

            if (street == null)
            {
                return NotFound();
            }

            return street;
        }

        // POST: api/Street
        [HttpPost]
        public async Task<ActionResult<Street>> PostStreet(Street street)
        {
            _context.Street.Add(street);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStreet), new { id = street.Id }, street);
        }

        // PUT: api/Street/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreet(int id, Street street)
        {
            if (id != street.Id)
            {
                return BadRequest();
            }

            _context.Entry(street).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Street/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreet(int id)
        {
            var street = await _context.Street.FindAsync(id);
            if (street == null)
            {
                return NotFound();
            }

            _context.Street.Remove(street);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StreetExists(int id)
        {
            return _context.Street.Any(e => e.Id == id);
        }
    }
}
