using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistAPI.Application.ViewModels.PresentTypeServices
{
    public class PresentTypesVm
    {
        public ICollection<PresentTypeDto> PresentTypes { get; set; }
        public int Count { get; set; }
    }
}
