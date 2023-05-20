using Airport_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Airport_API.Db
{
    public class AirportDbContext : DbContext 
    {
        public DbSet<AirCompany> AirCompanies { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<City> Cities { get; set; }

        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options)
        {
        }
    }
}
