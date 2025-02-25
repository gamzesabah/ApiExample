using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Entities.Concrete;


namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public virtual User User { get; set; } = default!;
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public DateTime? UpdatedAt { get; set; }
    }
}
