using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent(Name ="Service")]
    public class ServiceComponent:ViewComponent
    {
        private readonly DataContext _dataContext;
        public ServiceComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.Services
                         where i.isActive == true
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
