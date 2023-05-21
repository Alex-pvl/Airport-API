using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : Controller
    {
        public readonly FlightService service;

        public FlightsController(AirportDbContext context)
        {
            this.service = new FlightService(context);
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            return Ok(service.GetFlights());
        }

        [HttpGet("{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = service.GetFlight(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(AddFlightRequest request)
        {
            var flight = service.CreateFlight(request);
            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var flight = service.GetFlight(id);
            if (flight == null)
            {
                return NotFound();
            }
            service.DeleteFlightById(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AddPassenger(int id, int passengerId)
        {
            service.AddPassenger(id, passengerId);
            return Ok();
        }
    }
}
