using System;
using System.Collections.Generic;
using System.Text;
using WishlistAPI.Domain.Common;

namespace WishlistAPI.Domain.Model
{
    public class Wishlist : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }


        public ICollection<Present> Presents { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
