using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Wishlists;

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishlistsController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistsController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("Search/{username}")]
        [Description("Returns list for searched username")]
        public async Task<ActionResult<WishlistsVm>> Get(string username)
        {
            var wishlist = await _wishlistService.GetWishlistByUserName(username);
            return Ok(wishlist);
        }
    }
}
