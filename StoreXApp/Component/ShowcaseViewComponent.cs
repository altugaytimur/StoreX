using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Services.Contracts;

namespace StoreXApp.Component
{
    public class ShowcaseViewComponent:ViewComponent
    {
        private readonly IManagerService _manager;

        public ShowcaseViewComponent(IManagerService manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke()
        {
            var products = _manager.ProductService.GetShowcaseProducts(false);   
            return View(products);
        }
    }
}
