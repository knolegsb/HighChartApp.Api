using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HighChartApp.Api.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}