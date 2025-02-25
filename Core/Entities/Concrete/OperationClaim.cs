using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
