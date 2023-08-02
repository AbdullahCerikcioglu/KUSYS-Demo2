using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot, new()
    {
        private readonly EfDbContext _context;
        public Repository(EfDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Table => Entity.AsQueryable();
        public DbSet<T> Entity => _context.Set<T>();

        public IUnitOfWork UnitOfWork => _context;

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entityAdded = await Entity.AddAsync(entity, cancellationToken);

            return entityAdded.Entity;
        }

        public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Entity.Remove(entity).Entity);
        }

        public  async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Entity.Update(entity).Entity);
        }
    }
}
