using System.Linq.Expressions;
using ÖdevDağıtım.API.Models;

namespace ÖdevDağıtım.API.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> Where(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}