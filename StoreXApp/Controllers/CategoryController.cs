using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Contracts;

namespace StoreXApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IManagerRepository _manager;

        public CategoryController(IManagerRepository manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.Category.FindAll(false);
            return View(model);
        }

        
       

    }
}
