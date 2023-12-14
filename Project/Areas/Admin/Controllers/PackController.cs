using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class PackController : Controller
    {
        private readonly DataContext _dataContext;
        public PackController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.Packs.OrderBy(m => m.PackID).ToList();
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
            var m = await _dataContext.Packs.FindAsync(id);
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
            var del = _dataContext.Packs.Find(id);
            if (del == null)
            {
                return
                    NotFound();
            }
            _dataContext.Packs.Remove(del);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var query = (from i in _dataContext.Packs
                         select new SelectListItem()
                         {
                             Text = i.PlaceName,
                             Value = i.PackID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            ViewBag.query = query;
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Pack p)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.Packs.AddAsync(p);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var sm = _dataContext.Packs.Find(id);
            if (sm == null)
                return NotFound();
            var query = (from i in _dataContext.Packs
                         select new SelectListItem()
                         {
                             Text = i.PlaceName,
                             Value = i.PackID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            ViewBag.query = query;
            return View(sm);
        }
        [HttpPost]
        [Route("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pack p)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Packs.Update(p);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
