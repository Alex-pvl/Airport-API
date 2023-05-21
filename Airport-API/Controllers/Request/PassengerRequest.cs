namespace Airport_API.Controllers.Request
{
    public class PassengerRequest
    {
        public string Name { get; set; }
        public string Passport { get; set; }
        public float? LuggageWeight { get; set; }
        public float? HandLuggageWeight { get; set; }
        public int? FlightId { get; set; }
    }
}
