using System.ComponentModel.DataAnnotations.Schema;

namespace MoroccoCities.Models
{
    public class Province
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        //public ICollection<City> Cities { get; set; }
    }

}
