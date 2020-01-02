using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HighChartApp.Api.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighChartApp.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        protected User TemporalUser = new User();

        protected void SetBaseUser(ClaimsPrincipal user)
        {
            if (user == null) TemporalUser = null;
            else if (user.Claims == null) TemporalUser = null;
            else if (user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Count() > 0)
            {
                TemporalUser.Id = user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value;
                TemporalUser.UserName = user.Claims.Where(x => x.Type == ClaimTypes.Name).First().Value;
                TemporalUser.Email = user.Claims.Where(x => x.Type == ClaimTypes.Email).First().Value;
                TemporalUser.Role = int.Parse(user.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value);
            }
            else TemporalUser = null;
        }
    }
}