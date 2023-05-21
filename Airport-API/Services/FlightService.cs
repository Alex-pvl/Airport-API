using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Airport_API.Services
{
    public class FlightService
    {
        public readonly AirportDbContext context;
        public readonly CityService cityService;
        public readonly AirCompanyService airCompanyService;

        public FlightService(AirportDbContext context)
        {
            this.context = context;
            this.cityService = new CityService(context);
            this.airCompanyService = new AirCompanyService(context);
        }

        public List<Flight> GetFlights()
        {
            return context.Flights.ToList();
        }

        public Flight? GetFlight(int Id)
        {
            var flight = context.Flights.FirstOrDefault(f => f.Id == Id);
            if (flight == null)
            {
                return null;
            }
            return flight;
        }

        public Flight CreateFlight(AddFlightRequest request)
        {
            var flight= new Flight
            { 
                CityFromId = request.CityFromId, 
                CityToId = request.CityToId,
                DepartureAt = request.DepartureAt,
                ArriveAt = request.ArriveAt,
                AirlineId = request.AitlineId,
                Airline = context.AirCompanies.FirstOrDefault(ac => ac.Id == request.AitlineId)
            };
            var record = context.Flights.Add(flight).Entity;
            context.SaveChanges();
            return record;
        }

        public Flight DeleteFlightById(int Id)
        {
            var flight = GetFlight(Id);
            var record = context.Flights.Remove(flight).Entity;
            context.SaveChanges();
            return record;
        }

        public string AddPassenger(int Id, int PassengerId)
        {
            var flight = GetFlight(Id);
            if (flight != null)
            {
                var passenger = context.Passengers.FirstOrDefault(p => p.Id == PassengerId);
                flight.PassengersCount++;
                context.SaveChanges();
                return "Success!";
            }
            return "Error!";
        }
    }
}
