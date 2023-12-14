using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent (Name ="Pack")]
    public class PackComponent : ViewComponent
    {
        private DataContext _dataContext;
        public PackComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.Packs
                         where i.isActive == true
                         select i).ToList();
                        
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
