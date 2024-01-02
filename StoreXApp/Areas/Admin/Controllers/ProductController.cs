using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreX.Application.Dtos.Product;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;

namespace StoreXApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IManagerService _manager;

        public ProductController(IManagerService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
                
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file) 
        {
            //IFormfile parametresinin nedeni formdan dosyanın file gelmesi ancak dtoda ve entityde url olması
           

            if (ModelState.IsValid)
            {
                //File Operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = string.Concat("/images/", file.FileName);
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetByProductForUpdate(id, false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = string.Concat("/images/", file.FileName);

                _manager.ProductService.UpdateByProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete([FromRoute(Name ="id")]int id)
        {
            _manager.ProductService.DeleteByProduct(id);
            return RedirectToAction("Index");
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "Id", "CategoryName", "1");
        }
    }
}
