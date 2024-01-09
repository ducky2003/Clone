using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Utilities;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class SlideController : Controller
    {
        private readonly DataContext _dataContext;
        public SlideController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.Slides.OrderBy(m=>m.SlideID).ToList();
            return View(query);
        }
    }
}
