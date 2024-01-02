using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreXContext context) : base(context)
        {
        }
    }
}
