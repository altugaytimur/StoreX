using StoreX.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Contracts
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);

    }
}
