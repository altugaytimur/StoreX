using StoreX.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Entities.Concrete
{
    public class Product:BaseEntity
    {
       
        public string? ProductName { get; set; } = string.Empty;

        
        public decimal Price { get; set; }
        public string? Summary { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } 

        //Navigation Property
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public bool ShowCase { get; set; }
    }
}
