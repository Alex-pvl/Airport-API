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
    public class AirCompaniesController : Controller
    {
        private readonly AirCompanyService service;

        public AirCompaniesController(AirportDbContext dbContext)
        {
            this.service = new AirCompanyService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAirCompanies()
        {
            return Ok(service.GetAirCompanies());
        }

        [HttpGet("{id}")]
        public IActionResult GetAirCompany(int id)
        {
            var airCompany = service.GetAirCompany(id);
            if (airCompany == null)
            {
                return NotFound();
            }
            return Ok(airCompany);
        }

        [HttpPost]
        public async Task<IActionResult> AddAirCompany(AddAirCompanyRequest request)
        {
            var airCompany = service.CreateAirCompany(request.Name, request.CityId);
            if (airCompany == null)
            {
                return BadRequest("Данная авиакомпания в таком городе уже существует.");
            }
            return CreatedAtAction("GetAirCompany", new { id = airCompany.Id }, airCompany);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAirCompany(int id)
        {
            var airCompany = service.GetAirCompany(id);
            if (airCompany == null)
            {
                return NotFound();
            }
            service.DeleteAirCompanyById(id);
            return NoContent();
        }
    }
}
