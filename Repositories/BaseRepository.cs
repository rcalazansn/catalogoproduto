using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly CatalagoContext CatalogoContext;

        public BaseRepository(CatalagoContext catalagoContext)
        {
            CatalogoContext = catalagoContext;
        }

        public async Task Add(TEntity obj)
        {
            await CatalogoContext.Set<TEntity>().AddAsync(obj);
        }

        public void Update(TEntity obj)
        {
            CatalogoContext.Attach(obj);
            CatalogoContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
        {
            CatalogoContext.Set<TEntity>().Remove(obj);
        }

        public async Task Delete(Guid id)
        {
            var obj = await Get(id);

             Delete(obj);
        }

        public async Task<TEntity> Get(Guid id)
        {
            var _result = await CatalogoContext.Set<TEntity>().FindAsync(id);

            if (_result == null)
            {
                throw new Exception("");
            }

            return _result;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await CatalogoContext.Set<TEntity>().ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await CatalogoContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            CatalogoContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}