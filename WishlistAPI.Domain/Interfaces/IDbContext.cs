using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Domain.Interfaces
{
    public interface IDbContext
    {
        DbSet<Present> Presents { get; set; }
        DbSet<Wishlist> Wishlists { get; set; }
        DbSet<PresentType> PresentTypes { get; set; }

        Task<int> SaveChangesAsync();
    }
}
