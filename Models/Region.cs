using System.ComponentModel.DataAnnotations.Schema;

namespace MoroccoCities.Models
{
    public class Region
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Province> Provinces { get; set; }
        public ICollection<City> Cities { get; set; }
    }
    public class RegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Province> Provinces { get; set; }
        public ICollection<City> Cities { get; set; }
    }

}
