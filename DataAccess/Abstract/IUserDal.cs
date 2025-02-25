
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
