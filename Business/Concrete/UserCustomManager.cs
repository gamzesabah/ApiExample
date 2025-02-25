using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Repository;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserCustomManager : ServiceRepository<User>, IUserCustomService
    {
        readonly IUserDal _userDal;

        public UserCustomManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public async Task<User> GetByMail(string email)
        {
            var data = await _userDal.GetByPredicateAsync(u => u.Email == email);
            return data;
        }
    }

}
