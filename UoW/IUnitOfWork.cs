using System;
using System.Threading.Tasks;

namespace API.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
