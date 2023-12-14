using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceAbstract { get; set; }
        public string? ServicePrice { get; set; }
        public string? ServiceImg { get; set;}
        public bool? isActive { get; set; }
    }
}
