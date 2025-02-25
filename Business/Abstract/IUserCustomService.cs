using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repository;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserCustomService : IServiceRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        Task<User> GetByMail(string email);
    }
}
