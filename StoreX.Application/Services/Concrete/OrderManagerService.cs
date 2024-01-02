using AutoMapper;
using StoreX.Application.Contracts;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services.Concrete
{
    public class OrderManagerService:IOrderService
    {
        private readonly IManagerRepository _manager;
        private readonly IMapper _mapper;

        public OrderManagerService(IManagerRepository manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.Save();
        }

        public Order? GetByOrder(int id)
        {
            return _manager.Order.GetByOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}
