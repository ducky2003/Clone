using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent(Name ="Slide")]
    public class SlideComponent : ViewComponent
    {
        private DataContext _context;
        public SlideComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _context.Slides
                         where i.isActive == true
                         select i ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
