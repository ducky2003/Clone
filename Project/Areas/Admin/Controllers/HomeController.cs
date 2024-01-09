using Microsoft.AspNetCore.Mvc;
using Project.Utilities;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (Functions.IsLogined())
                return NotFound();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");           
            return View();
        }
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = string.Empty;
			Functions._UserEmail = string.Empty;
			Functions._Mess = string.Empty;
			Functions._MessEmail = string.Empty;
          
            return RedirectToAction("Index","Home", new {Area = ""});
		}

    }
}
