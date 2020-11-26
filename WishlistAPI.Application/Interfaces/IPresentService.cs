using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Application.ViewModels.Presents;

namespace WishlistAPI.Application.Interfaces
{
    public interface IPresentService
    {
        Task<PresentsVm> GetAllPresent();
        Task<PresentDto> GetPresentById(int id);
        Task AddNewPresent(CreatePresentDto newPresent);
        Task DeletePresent(int id);
        Task UpdatePresent(UpdatePresentDto updatePresent);
        Task<PresentsVm> GetPresentsByQuery(string query);
    }
}
