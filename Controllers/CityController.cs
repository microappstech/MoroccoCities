using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MoroccoCities.Data;
using MoroccoCities.Models;

namespace MoroccoCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class CityController : BaseController
    {
        public CityController(AppDbContext appDb) : base(appDb)
        {
        }

        [HttpGet("Cities")]
        public async Task<ApiResponse<IEnumerable<City>>> Get()
        {
            var res = await this.Context.City.ToListAsync();
            return new ApiResponse<IEnumerable<City>>(true, res);
        }

        [HttpGet("CitiesWithRegions")]
        public async Task<ApiResponse<IEnumerable<City>>> CitiesWithRegions()
        {
            var res = await this.Context.City.Include(i=>i.Region).ToListAsync();
            return new ApiResponse<IEnumerable<City>>(true, res);
        }

        [HttpGet("{id}")]
        public ApiResponse<City> Get(int id)
        {
            var res = this.Context.City.FirstOrDefault(i => i.Id == id);
            if (res == null)
                return new ApiResponse<City>(false, null, "city unfound");
            return new ApiResponse<City>(true, res);
        }
        [HttpGet("SearchByName")]
        public ApiResponse<List<City>> Get(string name)
        {
            var res = this.Context.City.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
            if (res == null)
                return new ApiResponse<List<City>>(false, null, "city unfound");
            return new ApiResponse<List<City>>(true, res);
        }

        //// POST api/<CityController>
        //[HttpPost]
        //public void Post([FromBody] City city)
        //{
        //    this.Context.City.Add(city);
        //    this.Context.SaveChanges();
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] City c)
        //{
        //    var item=Context.City.FirstOrDefault(i=>i.Id == id);
        //    if (item == null)
        //        return NotFound();
        //    item.Name = c.Name;
        //    item.Population = c.Population;
        //    item.RegionId = c.RegionId;
        //    item.PostalCode = c.PostalCode;

        //    Context.City.Update(item);
        //    Context.SaveChanges();
        //    return Ok();
        //}

        //// DELETE api/<CityController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var it = Context.City.FirstOrDefault(i=>i.Id==id);
        //    if(it==null)
        //        return NotFound();
        //    Context.City.Remove(it);
        //    Context.SaveChanges();
        //    return Ok();

        //}
    }
}
