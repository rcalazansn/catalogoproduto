using API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        Task<bool> Inserir(TEntity obj);

        Task<bool> Editar(TEntity obj);

        Task<TEntity> Obter(Guid id);

        Task<IEnumerable<TEntity>> Obter();

        Task<bool> Apagar(Guid id);
    }
}
