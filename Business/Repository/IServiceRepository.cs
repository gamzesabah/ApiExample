using Core.Entities;
using Core.Utilities.Results;

namespace Business.Repository
{
    public interface IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<bool> AnyAsync(Guid id);

        Task<IDataResult<TEntity?>> GetAsync(Guid id);

        Task<IDataResult<TEntity>> AddAsync(TEntity entity);
        Task<List<IDataResult<TEntity>>> AddRangeAsync(List<TEntity> entities);
        Task<IDataResult<TEntity>> UpdateAsync(TEntity entity);
        Task<List<IDataResult<TEntity>>> UpdateRangeAsync(List<TEntity> entities);
        Task<IResult> DeleteAsync(Guid id);
        Task<List<IResult>> DeleteRangeAsync(List<Guid> ids);
        Task<IDataResult<List<TEntity>>> GetAllAsync();
    }
}
