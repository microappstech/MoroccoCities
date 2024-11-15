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
    public class ProvinceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProvinceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Province
        [HttpGet("GetProvinces")]
        public async Task<ApiResponse<IEnumerable<Province>>> GetProvinces()
        {
            var res = await _context.Province.ToListAsync();
            return new ApiResponse<IEnumerable<Province>>(true, res);
        }

        // GET: api/Province
        [HttpGet("GetProvincesWithRegion")]
        public async Task<ApiResponse<IEnumerable<Province>>> GetProvincesWithRegion()
        {
            var res= await _context.Province.Include(i=>i.Region).ToListAsync();
            return new ApiResponse<IEnumerable<Province>>(true,res);
        }

        // GET: api/Province/5
        [HttpGet("{id}")]
        public async Task<ApiResponse<Province>> GetProvince(int id)
        {
            var province = await _context.Province.FindAsync(id);

            if (province == null)
            {
                return new ApiResponse<Province>(false, null, "No item found");
            }

            return new ApiResponse<Province>(true, province);
        }

        // GET: api/Province/5
        [HttpGet("SearchProvince")]
        public async Task<ApiResponse<List<Province>>> SearchProvince(string name)
        {
            var province = await _context.Province.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            if (province == null)
            {
                return new ApiResponse<List<Province>>(false, null, "No item found");
            }

            return new ApiResponse<List<Province>>(true, province);
        }

        // POST: api/Province
        //[HttpPost]
        //public async Task<ActionResult<Province>> PostProvince(Province province)
        //{
        //    _context.Province.Add(province);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetProvince), new { id = province.Id }, province);
        //}

        //// PUT: api/Province/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProvince(int id, Province province)
        //{
        //    if (id != province.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(province).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProvinceExists(id))
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

        //// DELETE: api/Province/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProvince(int id)
        //{
        //    var province = await _context.Province.FindAsync(id);
        //    if (province == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Province.Remove(province);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ProvinceExists(int id)
        {
            return _context.Province.Any(e => e.Id == id);
        }
    }
}
