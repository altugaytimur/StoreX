using StoreX.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string? CategoryName { get; set; } = string.Empty;

        //Navigation Property
        public ICollection<Product>? Products { get; set; }
    }
}
