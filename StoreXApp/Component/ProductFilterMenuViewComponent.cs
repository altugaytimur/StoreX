using Microsoft.AspNetCore.Mvc;

namespace StoreXApp.Component
{
    public class ProductFilterMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
