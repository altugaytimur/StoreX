using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using StoreXApp.Infra.Extensions;

namespace StoreXApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IManagerService _manager;
       
        public Cart Cart { get; set; } //IOC
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IManagerService manager ,Cart cartService)
        {
            _manager = manager;
            Cart = cartService;
           
        }

       
       
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); //Eðer bir cart nesnemiz varsa getirir yoksa yeni bir cart nesnesi yaratýr
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetByProduct(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new {returnUrl=returnUrl}); //ReturnUrl
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id.Equals(id)).Product);
            
            return Page();
        }

        public IActionResult OnPostClear(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetByProduct(productId, false);
            if (product is not null)
            {
                
                Cart.ClearItem(product, 1);
                
            }
            return Page();
        }
    }
}
