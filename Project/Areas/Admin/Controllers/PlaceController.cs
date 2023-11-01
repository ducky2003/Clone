using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlaceController : Controller
    {            
            private readonly DataContext _dataContext;
            public PlaceController(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public IActionResult Index()
            {
                var query = _dataContext.Places.OrderBy(m => m.PlaceID).ToList();
                return View(query);
            }
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var m = await _dataContext.Places.FindAsync(id);
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
                var del = _dataContext.Places.Find(id);
                if (del == null)
                {
                    return
                        NotFound();
                }
                _dataContext.Places.Remove(del);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Create()
            {
                var query = (from i in _dataContext.Places
                             select new SelectListItem()
                             {
                                 Text = i.PlaceName,
                                 Value = i.PlaceID.ToString(),
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
            public async Task<IActionResult> Create(Place pl)
            {
                if (ModelState.IsValid)
                {
                    await _dataContext.Places.AddAsync(pl);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(pl);
            }
            [HttpGet]
            [Route("Edit/{id:int}")]
            public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                    return NotFound();
                var sm = _dataContext.Places.Find(id);
                if (sm == null)
                    return NotFound();
                var query = (from i in _dataContext.Places
                             select new SelectListItem()
                             {
                                 Text = i.PlaceName,
                                 Value = i.PlaceID.ToString(),
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
            public async Task<IActionResult> Edit(Place p)
            {
                if (ModelState.IsValid)
                {
                    _dataContext.Places.Update(p);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(p);
            }
        }
}
