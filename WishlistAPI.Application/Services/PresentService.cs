using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Presents;
using WishlistAPI.Domain.Interfaces;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Application.Services
{
    public class PresentService : IPresentService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public PresentService(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PresentsVm> GetAllPresent()
        {
            var presents =
                await _context.Presents
                    .ProjectTo<PresentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return new PresentsVm()
            {
                Presents = presents,
                Count = presents.Count
            };
        }

        public async Task<PresentDto> GetPresentById(int id)
        {
            var present = await _context.Presents.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PresentDto>(present);
        }

        public async Task AddNewPresent(CreatePresentDto newPresent)
        {
            var present = _mapper.Map<Present>(newPresent);
            await _context.Presents.AddAsync(present);
            await _context.SaveChangesAsync();

        }

        public async Task DeletePresent(int id)
        {
            var present = await _context.Presents.FirstOrDefaultAsync(p => p.Id == id);
            _context.Presents.Remove(present);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePresent(UpdatePresentDto updatePresent)
        {
            var existingPresent = await _context.Presents
                .FirstOrDefaultAsync(p => p.Id == updatePresent.Id);

            _mapper.Map(updatePresent, existingPresent);
            await _context.SaveChangesAsync();
        }

        public async Task<PresentsVm> GetPresentsByQuery(string query)
        {
            var presents = await _context.Presents
                .Where(p => p.Name.ToLower()
                    .Contains(query.ToLower())).ProjectTo<PresentDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PresentsVm()
            {
                Presents = presents,
                Count = presents.Count
            };
        }
    }
}
