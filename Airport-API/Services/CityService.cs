using Airport_API.Db;
using Airport_API.Models;
using System.Xml.Linq;

namespace Airport_API.Services
{
    public class CityService
    {
        private readonly AirportDbContext dbContext;

        public CityService(AirportDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }

        public City? GetCity(int Id)
        {
            var city = dbContext.Cities.FirstOrDefault(c => c.Id == Id);
            if (city == null)
            {
                return null;
            }
            return city;
        }

        public City? CreateCity(string Name)
        {
            City existed = dbContext.Cities.FirstOrDefault(c => c.Name.Equals(Name));
            if (existed != null)
            {
                return null;
            }
            var city = new City { Name = Name };
            var record = dbContext.Cities.Add(city).Entity;
            dbContext.SaveChanges();
            return record;
        }

        public City DeleteCityById(int Id)
        {
            var city = GetCity(Id);
            var record = dbContext.Cities.Remove(city).Entity;
            dbContext.SaveChanges();
            return record;
        }
    }
}
