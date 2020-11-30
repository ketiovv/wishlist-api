using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WishlistAPI.Application.Mapping;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Application.ViewModels.PresentTypeServices
{
    public class CreatePresentTypeDto : IMapFrom<PresentType>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePresentTypeDto, PresentType>();
        }
    }
}
