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
    public class CreatePresentDto : IMapFrom<Present>
    {
        public string Name { get; set; }
        public string TypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePresentDto, Present>()
                .ForMember(d => d.PresentTypeId,
                    opt => opt.MapFrom(
                        src => src.TypeId));
        }
    }
}
