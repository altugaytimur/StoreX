using StoreX.Application.Contracts;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Services.Concrete
{
    public class CategoryManagerService : ICategoryService
    {
        private readonly IManagerRepository _manager;

        public CategoryManagerService(IManagerRepository manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

     
    }
}
