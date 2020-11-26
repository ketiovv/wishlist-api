using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Wishlists;
using WishlistAPI.Domain.Interfaces;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistService(IDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<WishlistsVm> GetWishlistByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var wishlists = await _context.Wishlists
                .Where(w => w.ApplicationUserId == user.Id)
                .ProjectTo<WishlistDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new()
            {
                Wishlists = wishlists,
                Count = wishlists.Count
            };
        }
    }
}
