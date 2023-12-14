using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/tip-{slug}-{id:long}.html", Name = "TipPost")]
        public IActionResult TipPost(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _dataContext.TravelTipss.Where
                (m => m.ParentID == id && m.IsActive == true && m.Levels == 1)
                .OrderBy(m => m.PostOrder)
                .Take(5).ToList();
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [Route("/place-{slug}-{id:long}.html", Name = "PlacePost")]
        public IActionResult PlacePost(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _dataContext.Places.Where
                (m => m.PlaceID == id && m.IsActive == true).ToList();
            if (post == null)
                return NotFound();
            return View(post);
        }
        [Route("/pre-{slug}-{id:long}.html", Name = "Pre")]
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}