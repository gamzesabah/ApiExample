using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Repositories.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EfCartItemDal : EfEntityRepositoryBase<CartItem>, ICartItemDal
    {
        private readonly AppDbContext _context;

        public EfCartItemDal(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
