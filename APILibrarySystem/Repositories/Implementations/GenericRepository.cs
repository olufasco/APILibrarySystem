using APILibrarySystem.Data;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILibrarySystem.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LibraryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual void Update(T entity) => _dbSet.Update(entity);

        public virtual void Delete(T entity) => _dbSet.Remove(entity);

        public virtual async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}