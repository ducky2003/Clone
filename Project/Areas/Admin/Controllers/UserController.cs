using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Areas.Admin.Models;
using Project.Models;
using Project.Utilities;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class UserController : Controller
    {
       private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.Userss.OrderBy(m => m.UserID).ToList();
            return View(query);
        }
        [HttpGet]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = await _dataContext.Userss.FindAsync(id);
            if (m == null)
            {
                return NotFound();

            }
            return View(m);
        }
        [HttpPost]
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            var delTip = _dataContext.Userss.Find(id);
            if (delTip == null)
            {
                return
                    NotFound();
            }
            _dataContext.Userss.Remove(delTip);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var sm = _dataContext.Userss.Find(id);
            if (sm == null)
                return NotFound();
            return View(sm);
        }
        [HttpPost]
        [Route("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users u)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Userss.Update(u);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }
    }
}
