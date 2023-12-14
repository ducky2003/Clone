using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("TravelTips")]
    public class TravelTip
    {
        [Key]
        public int TipID { get; set; }
        public string? TipTitle { get; set; }
        public string? TipContent { get; set; }
        public bool? IsActive { get; set; }
        public int ParentID { get; set; }
        public int Levels { get; set; }
        public int PostOrder { get; set; }
        public string? Timg { get; set; }
    }
}
