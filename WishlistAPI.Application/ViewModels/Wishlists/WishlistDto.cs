using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WishlistAPI.Application.Mapping;
using WishlistAPI.Application.ViewModels.Presents;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Application.ViewModels.Wishlists
{
    public class WishlistDto : IMapFrom<Wishlist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public List<PresentDto> Presents { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Wishlist, WishlistDto>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));

        }
    }
}
