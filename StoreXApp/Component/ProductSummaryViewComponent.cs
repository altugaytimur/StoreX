using Microsoft.AspNetCore.Mvc;
using StoraX.Infrastructure.Context;
using StoreX.Application.Services.Contracts;

namespace StoreXApp.Component
{
    public class ProductSummaryViewComponent:ViewComponent
    {
        private readonly IManagerService _manager;

        public ProductSummaryViewComponent(IManagerService manager)
        {
            _manager = manager;
        }

        public string Invoke() 
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
