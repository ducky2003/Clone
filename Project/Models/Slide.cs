using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public int SlideID { get; set;}
        public string? SlideImg { get; set;}
        public string? SlideContent { get; set;}
        public bool? isActive { get; set;}
    }
}
