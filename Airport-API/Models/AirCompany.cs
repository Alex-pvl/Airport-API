using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport_API.Models
{
    [Table("air_companies")]
    public class AirCompany
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [Column("name")]
        public string Name { get; set; } = null!;

        [Required]
        [Column("id_city")]
        [ForeignKey("City")]
        public int LocalityId { get; set; }
        [NotMapped]
        public City City { get; set; }
    }
}