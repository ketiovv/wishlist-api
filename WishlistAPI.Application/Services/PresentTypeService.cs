using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.PresentTypeServices;
using WishlistAPI.Domain.Interfaces;

namespace WishlistAPI.Application.Services
{
    public class PresentTypeService : IPresentTypeService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public PresentTypeService(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Task<PresentTypesVm> GetAllPresentTypes()
        {
            throw new NotImplementedException();
        }

        public Task DeletePresentType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
