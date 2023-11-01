using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("Place")]
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }
        public string? PlaceImage { get; set; }
        public string? PlaceSale { get; set; }

        public string? PlaceName { get; set; }
        public string? PlaceContent { get; set;}
        public bool? IsActive { get; set; }

    }
}
