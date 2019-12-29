using HighChartApp.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighChartApp.Api.Services
{
    public interface IAuthService
    {
        string CreateToken(User identityUser);
    }
}
