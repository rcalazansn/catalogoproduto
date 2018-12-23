using API.Models;
using API.Repositories;
using API.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IUnitOfWork UnitOfWork;

        private readonly IBaseRepository<TEntity> BaseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            BaseRepository = baseRepository;
        }

        public virtual async Task<bool> Inserir(TEntity obj)
        {
            await BaseRepository.Add(obj);

            return await UnitOfWork.Commit();
        }

        public virtual async Task<bool> Editar(TEntity obj)
        {
            BaseRepository.Update(obj);

            return await UnitOfWork.Commit();
        }

        public virtual async Task<bool> Apagar(Guid id)
        {
            await BaseRepository.Delete(id);

            return await UnitOfWork.Commit();
        }

        public virtual async Task<TEntity> Obter(Guid id)
        {
            return await BaseRepository.Get(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Obter()
        {
            return await BaseRepository.Get();
        }
    }
}
