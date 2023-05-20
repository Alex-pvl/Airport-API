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

        [Required]
        [Column("id_city_from")]
        [ForeignKey("CityFrom")]
        public int CityFromId { get; set; }
        [NotMapped]
        public City CityFrom { get; set; }

        [Required]
        [Column("id_city_to")]
        [ForeignKey("CityTo")]
        public int CityToId { get; set; }
        [NotMapped]
        public City CityTo { get; set; }

        [Required]
        [Column("departure_at")]
        public DateTime DepartureAt { get; set; }

        [Required]
        [Column("arrive_at")]
        public DateTime ArriveAt { get; set; }

        [NotMapped]
        public List<Passenger> Passengers { get; set; } = null!;

        [Column("id_airline")]
        [ForeignKey("Airline")]
        public int AirlineId { get; set; }

        [NotMapped]
        public AirCompany Airline { get; set; } = null!;
    }
}
