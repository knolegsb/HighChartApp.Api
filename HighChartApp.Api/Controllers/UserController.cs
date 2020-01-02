using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighChartApp.Api.Entities;
using HighChartApp.Api.Repository;
using HighChartApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighChartApp.Api.Controllers
{    
    public class UserController : Controller
    {
        private IUserRepository _userRepo;
        private IAuthService _authService;

        public UserController(IUserRepository userRepo, IAuthService authService)
        {
            _userRepo = userRepo;
            _authService = authService;
        }

        [Route("signup")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<User> Signup([FromBody]User newUser)
        {
            var response = await _userRepo.AddUser(newUser);
            return response;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}