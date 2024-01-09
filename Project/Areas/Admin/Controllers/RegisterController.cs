using Microsoft.AspNetCore.Mvc;
using Project.Areas.Admin.Models;
using Project.Models;
using Project.Utilities;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RegisterController : Controller
    {
        private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Users user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _dataContext.Userss.Where(m => m.UserEmail == user.UserEmail).FirstOrDefault();
            if (check != null)
            {
                Functions._MessEmail = "Email đã tồn tại";
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
    
