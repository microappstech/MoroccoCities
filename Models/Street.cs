using System.ComponentModel.DataAnnotations.Schema;

namespace MoroccoCities.Models
{
    public class Street
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string StreetCode { get; set; }  // Optional identifier for administrative use
    }

}
