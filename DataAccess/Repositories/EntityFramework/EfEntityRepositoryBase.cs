using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace DataAccess.Repositories.EntityFramework;

public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    private readonly DbContext _context;
    private DbSet<TEntity> _entities;

    public EfEntityRepositoryBase(DbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    protected virtual DbSet<TEntity> Entities => _entities ??= _context.Set<TEntity>();
    public IQueryable<TEntity> Table => Entities;
    public IQueryable<TEntity> AsNoTracking => Entities.AsNoTracking();
    public async Task<bool> AnyAsync(Guid id) => await Entities.FindAsync(id) != null;

    public async Task<TEntity?> GetAsync(Guid id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await Entities.SingleOrDefaultAsync(filter);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!)
    {
        return await (filter == null ? Entities.ToListAsync() : Entities.Where(filter).ToListAsync());
    }

    public async Task AddAsync(TEntity entity)
    {
        await Entities.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Entities.Update(entity);
        await SaveChangesAsync();
        _context.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Entities.Remove(entity);
        await SaveChangesAsync();
    }


    private async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            throw new Exception(GetFullError(e));
        }
    }
    private string GetFullError(DbUpdateException e)
    {
        var entries = _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
        foreach (var entry in entries)
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }

        return e.ToString();
    }
}
