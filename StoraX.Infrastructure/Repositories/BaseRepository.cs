using Microsoft.EntityFrameworkCore;
using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Repositories
{
    //Temel sınıfların instance alınmaması için abstract yapıyoruz. Absract sınıflar soyut olduğun için concrete hale getirilemez.
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        //Alt sınıflarda da contexti kullanabilmek için protected yapıyoruz.
        protected readonly StoreXContext _context;

        protected BaseRepository(StoreXContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            // _context.Set<T>(): Entity Framework'te, veritabanındaki belirli bir tür/tabloya (bu durumda T türü) erişim sağlamak için Set<T>() fonksiyonu kullanılır.
            //AsNoTracking(): Bu fonksiyon, sorgulanan nesnelerin değişiklik izlemesi olmadan getirilmesini sağlar. Bu, performansı artırabilir, çünkü EF, bu nesnelerdeki değişiklikleri takip etmez.
            //Ternary ifade(? :): Bu, kısaca bir if-else ifadesidir.Eğer trackChanges true ise _context.Set<T>() çağrılır ve değişiklikler izlenir. Eğer trackChanges false ise _context.Set<T>().AsNoTracking() çağrılır ve değişiklikler izlenmez.
            //Bu fonksiyonun amacı, kodun farklı bölümlerinde verinin ya izlenerek ya da izlenmeden sorgulanmasına olanak tanımaktır. Bu, performans ve veritabanı ile etkileşim konularında esneklik sağlar.

            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();

        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                 ? _context.Set<T>().Where(expression).SingleOrDefault()
                 : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
