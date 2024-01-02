using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;

namespace StoreXApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IManagerService _manager;
        private readonly Cart _cart;


        public OrderController(IManagerService manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.Id });
            }
            else
                return View();
            
        }
       
    }
}
