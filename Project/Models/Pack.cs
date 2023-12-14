using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    [Table("Pack")]
    public class Pack
    {
        [Key]
        public int PackID { get; set; }
        public string? PackDate { get; set; }
        public string? PackCount { get; set; }
        public string? PackPrice { get; set; }
        public string? PackTitle { get; set; }
        public string? PackContent { get; set; }
        public int PlaceID { get; set; }
        public bool? isActive { get; set; }
        public string? PackImg { get; set; }
        public string? PlaceName { get; set; }
    }
}
