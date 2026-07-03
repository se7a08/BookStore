using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly BookStoreContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(BookStoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        =>await _dbSet.AddAsync(entity);

        public void Delete(T entity)
        => _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()
        =>await _dbSet.ToListAsync();

        public async Task<T> GetByIDAsync(int id)
        => await _dbSet.FindAsync(id);

        public async Task SaveChangesAsync()
        =>await _context.SaveChangesAsync();

        public void Update(T entity)
        =>_dbSet.Update(entity);
    }
}
