using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Repositories;

namespace Business.Repository
{
    public class ServiceRepository<TEntity> : IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _repository;

        public ServiceRepository(IEntityRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> AnyAsync(Guid id)
        {
            return await _repository.AnyAsync(id);
        }
        public async Task<IDataResult<TEntity?>> GetAsync(Guid id)
        {
            var data = await _repository.GetAsync(id);
            return new SuccessDataResult<TEntity?>(data);
        }
        public async Task<IDataResult<TEntity>> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return new SuccessDataResult<TEntity>(entity);
        }
        public async Task<List<IDataResult<TEntity>>> AddRangeAsync(List<TEntity> entities)
        {
            var result = new List<IDataResult<TEntity>>();
            foreach (var entity in entities)
            {
                result.Add(await AddAsync(entity));
            }

            return result;
        }
        public async Task<IDataResult<TEntity>> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return new SuccessDataResult<TEntity>(entity);
        }
        public async Task<List<IDataResult<TEntity>>> UpdateRangeAsync(List<TEntity> entities)
        {
            var result = new List<IDataResult<TEntity>>();
            foreach (var entity in entities)
            {
                result.Add(await UpdateAsync(entity));
            }

            return result;
        }
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity!);
            return new SuccessDataResult<Guid>(id);
        }
        public async Task<List<IResult>> DeleteRangeAsync(List<Guid> ids)
        {
            var result = new List<IResult>();
            foreach (var id in ids) result.Add(await DeleteAsync(id));
            return result;
        }

        public async Task<IDataResult<List<TEntity>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            if (!result.Any())
            {
                return new ErrorDataResult<List<TEntity>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<TEntity>>(result, Messages.Found);
        }
    }

}
