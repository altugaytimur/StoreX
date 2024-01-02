using AutoMapper;
using StoreX.Application.Contracts;
using StoreX.Application.Dtos.Product;
using StoreX.Application.Mapper;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using StoreX.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services.Concrete
{
    public class ProductManagerService : IProductService
    {
        private readonly IManagerRepository _manager;
        private readonly IMapper _mapper;

    

        public ProductManagerService(IManagerRepository manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteByProduct(int id)
        {
            var product = GetByProduct(id, false);
            if (product is not null)
            {
                _manager.Product.DeleteProduct(product);
                _manager.Save();
            }
           
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }

        public Product? GetByProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetByProduct(id, trackChanges);
            if (product is null)
                throw new Exception("Product not found!");
            return product;
            
        }

        public ProductDtoForUpdate GetByProductForUpdate(int id, bool trackChanges)
        {
            var product = GetByProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
          return _manager
                .Product
                .FindAll(trackChanges)
                .OrderByDescending(prd=>prd.Id)
                .Take(n); 
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
           var data=_manager.Product.GetShowcaseProducts(trackChanges);
            return data;
        }

        public void UpdateByProduct(ProductDtoForUpdate productDto)
        {
            //var entity = _manager.Product.GetByProduct(productDto.Id, true);

            ////Eğer burada mapping kullanırsak EF Core entity'i izlemez ve repoda metot tanımlamamız gerekir.Burada tercih yapmak gerekir   automapper  custom map mi? yapıyoruz.  
            //entity.ProductName = productDto.ProductName;
            //entity.Price = productDto.Price;
            //entity.CategoryId = productDto.CategoryId;
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateByProduct(entity);
            _manager.Save();
        }

  
    }
}
