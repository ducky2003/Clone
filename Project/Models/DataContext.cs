using Microsoft.EntityFrameworkCore;
using Project.Areas.Admin.Models;

namespace Project.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<TravelTip> TravelTipss { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Pack> Packs { get; set; }  
        public DbSet<Service> Services { get; set; }
        public DbSet<Users> Userss { get; set; } 
        public DbSet<Slide> Slides { get; set; }
    }
}
