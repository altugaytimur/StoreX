using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using StoreX.Entities.RequestParameters;
using StoreXApp.Models;

namespace StoreXApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IManagerService _manager;



        public ProductController(IManagerService manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            //ındex viewde product List tipinde alınıyor bu yüzden Queryable olan sorguyu list'e çevirdik. Bunun yerinde index içerisinde List<Product> yerine Quearyable<Product> yazabilirdik.
            var products = _manager.ProductService.GetAllProductsWithDetails(p).ToList();
            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            // Product product = _context.Products.First(p=>p.Id.Equals(id));
            var model = _manager.ProductService.GetByProduct(id, false);
            return View(model);

        }














        //---------------------------------------------------------------------------------------------------------------
        ////public IEnumerable<Product> Index()
        ////{
        ////    ////DI olmadan veri tabanına ulaşım sağlanma yöntemi
        ////    //var context = new RepositoryContext(
        ////    //    new DbContextOptionsBuilder<RepositoryContext>()
        ////    //    .UseSqlite("Data Source=C:\\Altuğ\\BTK\\MVCStudio\\ProductDb.db")
        ////    //    .Options);


        ////    return _context.Products;
        ////}


    }
}
