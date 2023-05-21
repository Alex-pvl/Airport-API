using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport_API.Models
{
    [Table("flights")]
    public class Flight
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_city_from")]
        public int? CityFromId { get; set; }
        public virtual City CityFrom { get; set; }

        [Column("id_city_to")]
        public int? CityToId { get; set; }
        public virtual City CityTo { get; set; }

        [Required]
        [Column("departure_at")]
        public DateTime DepartureAt { get; set; }

        [Required]
        [Column("arrive_at")]
        public DateTime ArriveAt { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; } = null!;

        [Column("id_airline")]
        public int? AirlineId { get; set; }

        public virtual AirCompany Airline { get; set; } = null!;

        public Flight() => Passengers = new List<Passenger>();
    }
}
