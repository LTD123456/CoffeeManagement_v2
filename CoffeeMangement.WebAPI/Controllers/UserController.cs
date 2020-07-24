using CoffeeMangement.Services.User;
using CoffeeMangement.Services.User.Model;
using CoffeeMangement.WebAPI.Controllers.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMangement.WebAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : APIControllerBaseController
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }
        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userServices.AuthentiCate(request);
            if(string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName Or PassWord Is Incorrect!!");
            }
            return Ok(new{ token = resultToken});
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServices.Register(request);
            if (!result)
            {
                return BadRequest("Register Unsuccessful!!");
            }
            return Ok();
        }
    }
}
