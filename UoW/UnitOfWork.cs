using API.Data;
using System.Threading.Tasks;

namespace API.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalagoContext CatalagoContext;

        public UnitOfWork(CatalagoContext catalagoContext)
        {
            CatalagoContext = catalagoContext;
        }

        public async Task<bool> Commit()
        {
            return await CatalagoContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            CatalagoContext.Dispose();
        }
    }
}
