using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Services.Contracts;

namespace StoreXApp.Component
{
    public class CategoriesMenuViewComponent:ViewComponent
    {
        private readonly IManagerService _manager;

        public CategoriesMenuViewComponent(IManagerService manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            return View(categories);
        }
    }
}
