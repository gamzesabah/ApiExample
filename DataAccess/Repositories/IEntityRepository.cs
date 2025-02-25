using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;
using Core.Entities;

namespace DataAccess.Repositories;

public interface IEntityRepository<TEntity> where TEntity : IEntity, new()
{
    IQueryable<TEntity> Table { get; }

    IQueryable<TEntity> AsNoTracking { get; }

    Task<bool> AnyAsync(Guid id);
    Task<TEntity?> GetAsync(Guid id);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!);
    Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> filter);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);


}
