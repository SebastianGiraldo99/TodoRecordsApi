using Microsoft.EntityFrameworkCore;
using TodoRecords.DBContext;
using TodoRecords.Domain.Models;
using TodoRecords.IAppServices;

namespace TodoRecords.AppServices
{
    public class TodoRecordAppService<T> : ITodoRecordAppService<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbSet;

        public TodoRecordAppService(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T> GetById(int id) => await _dbSet.FindAsync(id);

        public async Task<T> Update(T entity, int id)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null) throw new Exception("No existe la tarea");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
