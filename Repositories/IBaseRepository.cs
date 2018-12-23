using API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        Task Delete(Guid id);

        Task<TEntity> Get(Guid id);

        Task<IEnumerable<TEntity>> Get();

        Task<int> SaveChanges();
    }
}
