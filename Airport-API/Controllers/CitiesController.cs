using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Models;
using Airport_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly CityService cityService;

        public CitiesController(AirportDbContext context)
        {
            this.cityService = new CityService(context);
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(cityService.GetCities());
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id) 
        {
            var city = cityService.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityRequest request)
        {
            var city = cityService.CreateCity(request.Name);
            if (city == null)
            {
                return BadRequest("Данный город уже существует.");
            }
            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = cityService.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            cityService.DeleteCityById(id);
            return NoContent();
        }
    }
}
