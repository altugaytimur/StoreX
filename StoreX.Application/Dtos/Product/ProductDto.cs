using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Dtos.Product
{
    public record ProductDto
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "Product Name is required")]
        public string? ProductName { get; init; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = string.Empty;
        public string? ImageUrl { get; set; }

        public int? CategoryId { get; init; }
    }
}


