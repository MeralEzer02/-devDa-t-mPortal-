using Microsoft.EntityFrameworkCore.Storage;

namespace ÖdevDağıtım.API.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> CommitAsync();
        void Commit();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}