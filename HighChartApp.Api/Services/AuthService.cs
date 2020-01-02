using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HighChartApp.Api.Entities;
using HighChartApp.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HighChartApp.Api.Services
{
    public class AuthService : IAuthService
    {
        private JwtOptions config;

        public AuthService(IOptions<JwtOptions> config)
        {
            this.config = config.Value;
        }

        public string CreateToken(User identityUser)
        {
            if(identityUser == null)
            {
                return "";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName),
                    //new Claim(ClaimTypes.Email, identityUser.Email),
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id.ToString()),
                    //new Claim(ClaimTypes.Role, identityUser.Role.ToString() )
                }),
                Issuer = config.Issuer,
                Audience = config.Audience,
                Expires = config.Expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                NotBefore = config.NotBefore
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
