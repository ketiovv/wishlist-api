using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Application.ViewModels.PresentTypeServices;

namespace WishlistAPI.Application.Interfaces
{
    public interface IPresentTypeService
    {
        Task<PresentTypesVm> GetAllPresentTypes();
        Task AddNewPresentType(CreatePresentTypeDto newPresentType);
        Task DeletePresentType(int id);
        //Task UpdatePresentType();
    }
}
