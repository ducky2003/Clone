using Microsoft.AspNetCore.Mvc;
using Project.Utilities;
using Project.Models;
using Project.Areas.Admin.Models;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class LoginController : Controller
	{
		private readonly DataContext _dataContext;
		public LoginController (DataContext dataContext)
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
			string pw = Functions.MD5Passwod(user.Pass);
			var check = _dataContext.Userss.Where(m=>(m.UserEmail == user.UserEmail) && (m.Pass == pw)).FirstOrDefault();
			
			if(check == null)
			{
				Functions._Mess = "Sai tên đăng nhập hoặc mật khẩu";
				return RedirectToAction("Index","Login");
			}
			Functions._Mess = string.Empty;
			Functions._UserID = check.UserID;
			Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
			Functions._UserEmail = string.IsNullOrEmpty(check.UserEmail) ? string.Empty : check.UserEmail;
			return RedirectToAction("Index", "Home", new {Area = ""});
		}
	}
}
