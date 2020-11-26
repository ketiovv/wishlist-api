using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Domain.Common;
using WishlistAPI.Domain.Interfaces;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Infrastructure
{
    public class Context : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<Present> Presents { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<PresentType> PresentTypes { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries().Where(e => e.Entity is AuditEntity &&
                                                             (e.State == EntityState.Added ||
                                                              e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((AuditEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(new());
        }
    }
}
