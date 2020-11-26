using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistAPI.Application.ViewModels.Presents
{
    public class PresentsVm
    {
        public ICollection<PresentDto> Presents { get; set; }
        public int Count { get; set; }
    }
}
