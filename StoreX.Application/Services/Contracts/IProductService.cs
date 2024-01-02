using StoreX.Application.Dtos.Product;
using StoreX.Entities.Concrete;
using StoreX.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLastestProducts(int n,bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
        Product? GetByProduct(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateByProduct(ProductDtoForUpdate product);
        void DeleteByProduct(int id);
        ProductDtoForUpdate GetByProductForUpdate(int id, bool trackChanges);
    }
    
}
