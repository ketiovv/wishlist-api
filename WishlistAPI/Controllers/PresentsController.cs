using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Presents;
using WishlistAPI.Domain.Model;

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresentsController : ControllerBase
    {
        private readonly IPresentService _presentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PresentsController(IPresentService presentService, UserManager<ApplicationUser> userManager)
        {
            _presentService = presentService;
            _userManager = userManager;
        }

        [HttpGet]
        [Description("Get a list of presents")]
        public async Task<ActionResult<PresentsVm>> Get()
        {
            var presents = await _presentService.GetAllPresent();
            // await _userManager.CreateAsync(new ApplicationUser()
            // {
            //     Email = "test3@test.com", 
            //     EmailConfirmed = true,
            //     UserName = "test3@test.com"
            // }, "ZAQ!2wsx");
            return Ok(presents);
        }

        [HttpGet("{id}")]
        [Description("Get present by id")]
        public async Task<ActionResult<PresentDto>> Get(int id)
        {
            var present = await _presentService.GetPresentById(id);
            return Ok(present);
        }

        [HttpGet("{query}")]
        [Description("Get present by query")]
        public async Task<ActionResult<PresentDto>> Get(string query)
        {
            var present = await _presentService.GetPresentsByQuery(query);
            return Ok(present);
        }

        [HttpPost]
        [Description("Inserts new item")]
        public async Task<ActionResult<PresentDto>> Create(CreatePresentDto newPresent)
        {
            await _presentService.AddNewPresent(newPresent);
            return NoContent();
        }

        [HttpPut]
        [Description("Updates specific item")]
        public async Task<ActionResult<PresentDto>> Update(UpdatePresentDto updatePresent)
        {
            await _presentService.UpdatePresent(updatePresent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Deletes specyfic item")]
        public async Task<ActionResult<PresentDto>> Delete(int id)
        {
            await _presentService.DeletePresent(id);
            return NoContent();
        }
    }
}
