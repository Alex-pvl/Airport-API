using Airport_API.Controllers.Request;
using Airport_API.Db;
using Airport_API.Models;

namespace Airport_API.Services
{
    public class PassengerService
    {
        public readonly AirportDbContext context;
        public readonly FlightService flightService;

        public PassengerService(AirportDbContext context)
        {
            this.context = context;
            this.flightService = new FlightService(context);
        }

        public List<Passenger> GetPassengers()
        {
            return context.Passengers.ToList();
        }

        public Passenger? GetPassenger(int Id)
        {
            var passenger = context.Passengers.FirstOrDefault(p => p.Id == Id);
            if (passenger == null)
            {
                return null;
            }
            return passenger;
        }

        public Passenger CreatePassenger(PassengerRequest request)
        {
            var passenger = new Passenger
            {
                Fullname = request.Name,
                Passport = request.Passport,
                LuggageWeight = request.LuggageWeight,
                HandLuggageWeight = request.HandLuggageWeight,
                FlightId = request.FlightId,
                Flight = context.Flights.FirstOrDefault(f => f.Id == request.FlightId)
            };
            var record = context.Passengers.Add(passenger).Entity;
            context.SaveChanges();
            return record;
        }

        public Passenger DeletePassengerById(int Id)
        {
            var passenger = GetPassenger(Id);
            var record = context.Passengers.Remove(passenger).Entity;
            context.SaveChanges();
            return record;
        }

        public Passenger UpdatePassengerById(int Id, PassengerRequest request)
        {
            var passenger = GetPassenger(Id);
            passenger.Fullname = request.Name;
            passenger.Passport = request.Passport;
            passenger.LuggageWeight = request.LuggageWeight;
            passenger.HandLuggageWeight = request.HandLuggageWeight;
            passenger.FlightId = request.FlightId;
            return passenger;
        }
    }
}
