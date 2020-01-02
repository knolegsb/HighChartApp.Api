using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighChartApp.Api.Dtos;
using HighChartApp.Api.Models;
using HighChartApp.Api.Repository;
using HighChartApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HighChartApp.Api.Controllers
{
    public class AuthController : BaseController
    {
        private IUserRepository _userRepo;
        private IAuthService _authService;
        private IOptions<JwtOptions> _config;

        public AuthController(IAuthService authService, IOptions<JwtOptions> config, IUserRepository userRepo)
        {
            _authService = authService;
            _config = config;
            _userRepo = userRepo;
        }

        [Route("token")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody]UserLoginDto userLoginDto)
        {
            var user = await _userRepo.GetUserByUsernameAndPassword(userLoginDto.username, userLoginDto.password);

            var token = _authService.CreateToken(user);

            if (token == "")
            {
                return BadRequest("Invalid username or password");
            }

            var result = new TokenResult()
            {
                access_token = token,
                expires_in = _config.Value.ExpiryMinutes * 60
            };
            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}