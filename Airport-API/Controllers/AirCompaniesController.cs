using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirCompaniesController : Controller
    {
        private readonly AirportDbContext dbContext;

        public AirCompaniesController(AirportDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAirCompanies()
        {
            return Ok(dbContext.AirCompanies.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddAirCompany(AddAirCompanyRequest request)
        {
            var airCompany = new AirCompany()
            {
                Name = request.Name,
                CityId = request.CityId,
                City = dbContext.Cities.FindAsync(request.CityId).Result
            };

            dbContext.AirCompanies.Add(airCompany);
            await dbContext.SaveChangesAsync();

            return Ok(airCompany);
        }
    }
}
