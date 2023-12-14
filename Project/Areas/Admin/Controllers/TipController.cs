using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class TipController :Controller
    {
        private readonly DataContext _dataContext;
        public TipController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.TravelTipss.OrderBy(m => m.TipID).ToList();
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
            var m = await _dataContext.TravelTipss.FindAsync(id);
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
            var delTip = _dataContext.TravelTipss.Find(id);
            if (delTip == null)
            {
                return
                    NotFound();
            }
            _dataContext.TravelTipss.Remove(delTip);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var query = (from i in _dataContext.TravelTipss
                         select new SelectListItem()
                         {
                             Text = i.TipTitle,
                             Value = i.TipID.ToString(),
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
        public async Task<IActionResult> Create(TravelTip tl)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.TravelTipss.AddAsync(tl);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tl);
        }
        [HttpGet]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var sm = _dataContext.TravelTipss.Find(id);
            if (sm == null)
                return NotFound();            
            return View(sm);
        }
        [HttpPost]
        [Route("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TravelTip tt)
        {
            if (ModelState.IsValid)
            {
                _dataContext.TravelTipss.Update(tt);
                 _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tt);
        }
        [HttpGet]
        [Route("CreatePost")]
        public IActionResult CreatePost()
        {
            var query = (from i in _dataContext.TravelTipss
                         select new SelectListItem()
                         {
                             Text = i.TipTitle,
                             Value = i.TipID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.query = query;
            return View();
        }
        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(TravelTip tp)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.TravelTipss.AddAsync(tp);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tp);
        }
    }
}
