using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.Options
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string CustomerName { get; set; }
        public string FullName { get; set; }
        public List<OperationClaim> Roles { get; set; }
    }
}
