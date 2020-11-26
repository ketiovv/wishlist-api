using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WishlistAPI.Application.Mapping;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Application.ViewModels.Presents
{
    public class PresentDto : IMapFrom<Present>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Present, PresentDto>()
                .ForMember(d => d.TypeName,
                    opt =>
                        opt.MapFrom(src => src.PresentType.Name));
        }
    }
}
