using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent(Name = "Place")]
    public class PlaceComponent : ViewComponent
    {
        private DataContext _context;
        public PlaceComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _context.Places
                         where i.IsActive == true
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
