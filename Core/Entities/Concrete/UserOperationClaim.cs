using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public User? User { get; set; }
        public OperationClaim? OperationClaim { get; set; }

    }
}
