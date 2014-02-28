using System.Linq;
using FootStat.Domain.Abstract;

namespace FootStat.Domain.Concrete {
    public class Repository<T> : IRepository<T> where T : class, IEntitie {
        private readonly SportStatEntities _context;

        public Repository() {
            _context = new SportStatEntities();
        }

        public void Dispose() {
            if (_context != null)
                _context.Dispose();
        }

        public void Add(T entity) {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity) {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity) {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll() {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id) {
            return _context.Set<T>().FirstOrDefault(p => p.Id == id);
        }
    }
}

