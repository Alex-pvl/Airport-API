using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : Controller
    {
        public readonly PassengerService service;

        public PassengersController(AirportDbContext context)
        {
            this.service = new PassengerService(context);
        }

        [HttpGet]
        public IActionResult GetPassengers()
        {
            return Ok(service.GetPassengers());
        }

        [HttpGet("{id}")]
        public IActionResult GetPassenger(int id)
        {
            var passenger = service.GetPassenger(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return Ok(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassenger(PassengerRequest request)
        {
            var passenger = service.CreatePassenger(request);
            return CreatedAtAction("GetPassenger", new { id = passenger.Id }, passenger);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePassenger(int id)
        {
            var passenger = service.GetPassenger(id);
            if (passenger == null)
            {
                return NotFound();
            }
            service.DeletePassengerById(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassenger(int Id, PassengerRequest request)
        {
            service.UpdatePassengerById(Id, request);
            return Ok();
        }
    }
}
