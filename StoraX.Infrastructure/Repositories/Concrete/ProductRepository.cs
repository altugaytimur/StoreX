using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Entities.Concrete;
using StoreX.Entities.RequestParameters;
using StoreX.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Repositories.Concrete
{
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreXContext context) : base(context)
        {
        }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice)
                .ToPaginate(p.PageNumber,p.PageSize);
           
            //Extension kullanmaz isek aşağıdaki logic işletilebilir
            //return p.CategoryId is null
            //    ? _context
            //    .Products
            //    .Include(pr => pr.Category)
            //    : _context
            //    .Products
            //    .Include(pr=> pr.Category)
            //    .Where(pr => pr.CategoryId.Equals(p.CategoryId));
        }

        public Product? GetByProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateByProduct(Product entity) => Update(entity);


    }
}
