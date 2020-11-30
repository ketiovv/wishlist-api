using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.PresentTypeServices;
using WishlistAPI.Domain.Interfaces;
using WishlistAPI.Domain.Model;

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


        public async Task<PresentTypesVm> GetAllPresentTypes()
        {
            var presentTypes =
                await _context.PresentTypes
                    .ProjectTo<PresentTypeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return new PresentTypesVm()
            {
                PresentTypes = presentTypes,
                Count = presentTypes.Count
            };
        }

        public async Task AddNewPresentType(CreatePresentTypeDto newPresentType)
        {
            var present = _mapper.Map<PresentType>(newPresentType);
            await _context.PresentTypes.AddAsync(present);
            await _context.SaveChangesAsync();
        }

        public Task DeletePresentType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
