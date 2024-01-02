using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;

namespace StoreXApp.Component
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private readonly Cart _cart;

     

        public CartSummaryViewComponent(Cart cartService)
        {
            _cart = cartService;
        }

        public string Invoke()
        {
            return _cart.Lines.Count().ToString();
        }
    }
}
