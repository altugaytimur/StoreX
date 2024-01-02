using Microsoft.EntityFrameworkCore;
using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Repositories.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreXContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o=>o.Lines)
            .ThenInclude(cl=>cl.Product)
            .OrderBy(o=>o.Shipped)
            .ThenByDescending(O=>O.Id);

        public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.Id.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped= true;
         
           
        }

        public Order? GetByOrder(int id)
        {
            return FindByCondition(o => o.Id.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
