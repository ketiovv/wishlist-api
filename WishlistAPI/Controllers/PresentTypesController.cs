using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Presents;
using WishlistAPI.Application.ViewModels.PresentTypeServices;

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresentTypesController : ControllerBase
    {
        private readonly IPresentTypeService _presentTypeService;

        public PresentTypesController(IPresentTypeService presentTypeService)
        {
            _presentTypeService = presentTypeService;
        }


        [HttpGet]
        [Description("Get a list of present types")]
        public async Task<ActionResult<PresentsVm>> Get()
        {
            var presentTypes = await _presentTypeService.GetAllPresentTypes();
            return Ok(presentTypes);
        }

        [HttpPost]
        [Description("Insert new present type")]
        public async Task<ActionResult<PresentTypeDto>> Create(CreatePresentTypeDto newPresentType)
        {
            await _presentTypeService.AddNewPresentType(newPresentType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Deletes specyfic type")]
        public async Task<ActionResult<PresentTypeDto>> Delete(int id)
        {
            await _presentTypeService.DeletePresentType(id);
            return NoContent();
        }

        [HttpPut]
        [Description("Updates specific type")]
        public async Task<ActionResult<PresentTypeDto>> Update(UpdatePresentTypeDto updatePresentType)
        {
            await _presentTypeService.UpdatePresentType(updatePresentType);
            return NoContent();
        }
    }
}
