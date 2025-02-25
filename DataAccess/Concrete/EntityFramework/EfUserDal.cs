using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Repositories.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntitiyFramework;

public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
{
    private readonly AppDbContext _context;
    public EfUserDal(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public List<OperationClaim> GetClaims(User user)
    {

        IQueryable<OperationClaim> result = from operationClaim in _context.OperationClaims
                                            join userOperationClaim in _context.UserOperationClaims
                                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                                            where userOperationClaim.UserId == user.Id
                                            select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
        return result.ToList();
    }
}



