using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.Repository;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : ServiceRepository<Product>, IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal) : base(productDal)
        {
            _productDal = productDal;
        }

        public async Task<DataResult<List<Product>>> GetAllProductsAsync()
        {
            var result = await _productDal.GetAllAsync();
            if (!result.Any())
            {
                return new ErrorDataResult<List<Product>>(Messages.NotFound);
            }

            return new SuccessDataResult<List<Product>>(result, Messages.Found);
        }
        public async Task<DataResult<Product>> CreateProductAsync(Product product)
        {
            if (product == null)
            {
                return new ErrorDataResult<Product>(Messages.NotFound);
            }
            await _productDal.AddAsync(product);

            return new SuccessDataResult<Product>(product, Messages.Added);
        }
        public async Task<DataResult<Product>> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return new ErrorDataResult<Product>(Messages.NotFound);
            }

            var existingProduct = await _productDal.GetAsync(product.Id);

            if (existingProduct == null)
            {
                return new ErrorDataResult<Product>(Messages.NotFound);
            }

            existingProduct = product;
            existingProduct.UpdatedAt = DateTime.UtcNow;
            await _productDal.UpdateAsync(existingProduct);

            return new SuccessDataResult<Product>(product, Messages.Updated);
        }
        public async Task<DataResult<Product>> DeleteProductAsync(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                return new ErrorDataResult<Product>(Messages.NotFound);
            }

            var product = await _productDal.GetAsync(productId);
            if (product == null)
            {
                return new ErrorDataResult<Product>(Messages.NotFound);
            }

            await _productDal.DeleteAsync(product);

            return new SuccessDataResult<Product>(product, Messages.Deleted);
        }
    }
}
