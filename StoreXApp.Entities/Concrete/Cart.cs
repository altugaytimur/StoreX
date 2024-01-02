using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Entities.Concrete
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public virtual void AddItem(Product product,int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.Id.Equals(product.Id)).FirstOrDefault();
            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product=product,
                    Quantity=quantity

                });
            }
            else
                line.Quantity += quantity;
           
        }
        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.Id.Equals(product.Id));
        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
        public virtual void ClearItem(Product product, int quantity)
        {
            var line= Lines.Where(l => l.Product.Id.Equals(product.Id)).FirstOrDefault();
            if (line is not null)
                if (line.Quantity != 1)
                    line.Quantity -= quantity;
                else
                    Lines.RemoveAll(l => l.Product.Id.Equals(product.Id));
        }
    }
}
