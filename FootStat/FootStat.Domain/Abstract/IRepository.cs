using System.Linq;

namespace FootStat.Domain.Abstract
{
    public interface IRepository<T> {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
