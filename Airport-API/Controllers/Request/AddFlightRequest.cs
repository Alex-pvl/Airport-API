namespace Airport_API.Controllers.Request
{
    public class AddFlightRequest
    {
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public DateTime DepartureAt { get; set; }
        public DateTime ArriveAt { get; set; }
        public int AitlineId { get; set; }

    }
}
