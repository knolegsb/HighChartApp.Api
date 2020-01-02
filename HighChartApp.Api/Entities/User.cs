using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighChartApp.Api.Entities
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string Username { get; set; }
        //public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Password { get; set; }
        public bool IsTemporalPassword { get; set; }
        public int? Role { get; set; }
    }
}
