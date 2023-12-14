using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Utilities;
using Project.Areas.Admin.Models;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RegisterController : Controller
    {
        private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext)
        {
            dataContext = _dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _dataContext.Users.Where(m => m.UserEmail == user.UserEmail).FirstOrDefault();
            if (check != null)
            {
                Functions._MessEmail = string.Empty;
                return RedirectToAction("Index", "Register");
            }
            Functions._MessEmail = string.Empty;
            user.Pass = Functions.MD5Passwod(user.Pass);
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
    
