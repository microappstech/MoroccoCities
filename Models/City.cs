using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


namespace MoroccoCities.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        public ICollection<Street> Streets { get; set; }
        public int? Population { get; set; }
        [JsonIgnore]
        public int? PostalCode { get; set; }
    }

}
