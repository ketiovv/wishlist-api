using System.Collections.Generic;
using WishlistAPI.Domain.Common;

namespace WishlistAPI.Domain.Model
{
    public class Present : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PresentTypeId { get; set; }


        public PresentType PresentType { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}