using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Components
{
    [ViewComponent(Name ="RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public RecentPostComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.TravelTipss
                         where i.IsActive == true && i.Levels == 0
                         orderby i.TipID descending
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("RecentPost", query));
        }
    }
}
