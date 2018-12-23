using API.Models;
using API.Repositories;
using API.UoW;

namespace API.Application
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IBaseRepository<Produto> baseRepository, IUnitOfWork unitOfWork) 
            : base(baseRepository, unitOfWork)
        {
        }
    }
}
