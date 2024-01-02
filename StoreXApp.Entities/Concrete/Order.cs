using StoreX.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Entities.Concrete
{
    public class Order:BaseEntity
    {
        [Required(ErrorMessage ="Name is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Line1 is Required")]
        public string? Line1 { get; set; }

        public string? Line2 { get; set; }

        public string? Line3 { get; set; }

        public string? City { get; set; }

        public bool GiftWrap { get; set; }

        public bool Shipped { get; set; }

        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
    }
}
