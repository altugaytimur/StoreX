using AutoMapper;
using StoreX.Application.Dtos.Product;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            //İki yönlü bir mapping işlemi yapacağımız için reverseMap metotunu kullanıyoruz.
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }
    }
}
