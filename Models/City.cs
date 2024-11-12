using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MoroccoCities.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public ICollection<Street> Streets { get; set; }
        public int Population { get; set; }
        public int PostalCode { get; set; }
    }

}
