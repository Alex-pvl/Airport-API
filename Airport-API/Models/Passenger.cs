using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport_API.Models
{
    [Table("passengers")]
    public class Passenger
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("fullname")]
        public string Fullname { get; set; }

        [Required]
        [Column("passport")]
        public string Passport { get; set; }

        [Column("luggage_weight")]
        public float LuggageWeight { get; set; }

        [Column("hand_luggage_weight")]
        public float HandLuggageWeight { get; set; }

        [Column("id_flight")]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        [NotMapped]
        public Flight Flight { get; set; }
    }
}
