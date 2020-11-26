using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Application.ViewModels.Wishlists;

namespace WishlistAPI.Application.Interfaces
{
    public interface IWishlistService
    {
        Task<WishlistsVm> GetWishlistByUserName(string userName);
    }
}
