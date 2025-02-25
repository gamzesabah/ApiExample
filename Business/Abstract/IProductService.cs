using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repository;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService : IServiceRepository<Product>
    {
        Task<DataResult<List<Product>>> GetAllProductsAsync();
        Task<DataResult<Product>> CreateProductAsync(Product product);
        Task<DataResult<Product>> UpdateProductAsync(Product product);
        Task<DataResult<Product>> DeleteProductAsync(Guid id);
    }
}
