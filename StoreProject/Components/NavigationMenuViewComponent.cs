using Microsoft.AspNetCore.Mvc;
using System.Linq;
using StoreProject.Models;
using System.Threading.Tasks;

namespace StoreProject.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IProductRepository _repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
