using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public bool Status { get; set; } = default!;
        public virtual ICollection<User> UserItems { get; set; } = new List<User>();
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();

    }
}
