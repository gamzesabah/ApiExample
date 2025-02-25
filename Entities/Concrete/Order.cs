using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = default!;
        public string PaymentStatus { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public virtual User User { get; set; } = default!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}