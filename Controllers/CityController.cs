using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MoroccoCities.Models;

namespace MoroccoCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        public CityController(AppDbContext appDb) : base(appDb)
        {
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return this.Context.City.AsNoTracking();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public City? Get(int id)
        {
            return this.Context.City.FirstOrDefault(i => i.Id == id);
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] City city)
        {
            this.Context.City.Add(city);
            this.Context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] City c)
        {
            var item=Context.City.FirstOrDefault(i=>i.Id == id);
            if (item == null)
                return NotFound();
            item.Name = c.Name;
            item.Population = c.Population;
            item.ProvinceId = c.ProvinceId;
            item.PostalCode = c.PostalCode;

            Context.City.Update(item);
            Context.SaveChanges();
            return Ok();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var it = Context.City.FirstOrDefault(i=>i.Id==id);
            if(it==null)
                return NotFound();
            Context.City.Remove(it);
            Context.SaveChanges();
            return Ok();

        }
    }
}
