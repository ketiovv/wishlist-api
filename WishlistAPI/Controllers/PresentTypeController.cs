﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishlistAPI.Application.Interfaces;
using WishlistAPI.Application.ViewModels.Presents;

namespace WishlistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresentTypeController : ControllerBase
    {
        private readonly IPresentTypeService _presentTypeService;

        public PresentTypeController(IPresentTypeService presentTypeService)
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
    }
}
