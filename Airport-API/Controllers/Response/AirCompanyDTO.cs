using Airport_API.Models;

namespace Airport_API.Controllers.Response
{
    public class AirCompanyDTO
    {
        public string Name;
        public City city;

        public AirCompanyDTO(City city) 
        {
            this.Name = city.Name;
            this.city = city;
        }
    }
}
