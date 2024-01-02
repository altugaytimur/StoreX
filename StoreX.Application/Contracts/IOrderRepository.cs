using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Contracts
{
    public interface  IOrderRepository:IBaseRepository<Order>
    {
        IQueryable<Order> Orders { get; }
        Order? GetByOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
    }
}
