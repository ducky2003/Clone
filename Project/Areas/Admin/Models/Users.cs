using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Areas.Admin.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Pass { get; set; }
        public bool? isActive { get; set; }
        public string? Sodienthoai { get; set; }
        public string? Diachi { get; set; }
    }
}
