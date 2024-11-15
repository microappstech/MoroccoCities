using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoroccoCities.Data;
using MoroccoCities.Models;

namespace MoroccoCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Regions")]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Region.ToListAsync();
        }
        [HttpGet("RegionsWithProvinces")]
        public async Task<ApiResponse<IEnumerable<Region>>> GetRegionsProvince()
        {
            var res = await _context.Region.Include(i=>i.Provinces).ToListAsync();
            return new ApiResponse<IEnumerable<Region>>(true, res, "");
        }


        // GET: api/Region/5
        [HttpGet("RegionById{id}")]
        public async Task<ApiResponse<Region>> GetRegion(int id)
        {
            var region = await _context.Region.FindAsync(id);

            if (region == null)
            {
                return new ApiResponse<Region>(false,null, "City bot found");
            }

            return new ApiResponse<Region>(true, region, string.Empty);
        }



        // GET: api/Region/5
        [HttpGet("RegionsByName")]
        public async Task<ApiResponse<List<Region>>> GetRegionByName(string name)
        {
            var region = _context.Region.Where(i=>i.Name.ToLower().Contains(name.ToLower())).ToList();
            if (region == null)
            {
                return new ApiResponse<List<Region>>(false,null,"No city with this name");
            }

            return new ApiResponse<List<Region>>(true,region);
        }

        //// POST: api/Region
        //[HttpPost]
        //public async Task<ActionResult<Region>> PostRegion(Region region)
        //{
        //    _context.Region.Add(region);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
        //}

        //// PUT: api/Region/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRegion(int id, Region region)
        //{
        //    if (id != region.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(region).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RegionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Region/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRegion(int id)
        //{
        //    var region = await _context.Region.FindAsync(id);
        //    if (region == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Region.Remove(region);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.Id == id);
        }
    }
}
