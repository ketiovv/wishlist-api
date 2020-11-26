using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WishlistAPI.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}