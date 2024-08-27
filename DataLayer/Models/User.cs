using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class User: IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        [JsonIgnore]
        public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();
       // public virtual ICollection<Wishlist>? Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
