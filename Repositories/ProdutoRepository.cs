using API.Data;
using API.Models;

namespace API.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CatalagoContext catalagoContext) : base(catalagoContext)
        {
        }
    }
}
