using System.Collections.Generic;

namespace WishlistAPI.Domain.Model
{
    public class PresentType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Present> Presents { get; set; }
    }
}