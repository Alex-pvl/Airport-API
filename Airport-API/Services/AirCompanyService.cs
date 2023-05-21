using Airport_API.Db;
using Airport_API.Models;

namespace Airport_API.Services
{
    public class AirCompanyService
    {
        private readonly AirportDbContext dbContext;
        private readonly CityService cityService;

        public AirCompanyService(AirportDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.cityService = new CityService(dbContext);
        }

        public List<AirCompany> GetAirCompanies()
        {
            return dbContext.AirCompanies.ToList();
        }

        public AirCompany? GetAirCompany(int Id)
        {
            var airCompany = dbContext.AirCompanies.FirstOrDefault(ac => ac.Id == Id);
            if (airCompany == null)
            {
                return null;
            }
            return airCompany;
        }

        public AirCompany? CreateAirCompany(string Name, int CityId)
        {
            // check existing
            var city = cityService.GetCity(CityId);
            var existingAC = dbContext.AirCompanies.FirstOrDefault(ac => ac.Name.Equals(Name) && ac.CityId == CityId);
            if (existingAC != null)
            {
                return null;
            }

            var airCompany = new AirCompany
            { 
                Name = Name, 
                CityId = CityId, 
                City = city 
            };
            var record = dbContext.AirCompanies.Add(airCompany).Entity;
            dbContext.SaveChanges();
            return record;
        }

        public AirCompany DeleteAirCompanyById(int Id)
        {
            var airCompany = GetAirCompany(Id);
            var record = dbContext.AirCompanies.Remove(airCompany).Entity;
            dbContext.SaveChanges();
            return record;
        }
    }
}
