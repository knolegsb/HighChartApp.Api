using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighChartApp.Api.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Subject { get; set; }

        public string Audience { get; set; }

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public DateTime NotBefore
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public DateTime IssuedAt
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public TimeSpan ValidFor => TimeSpan.FromMinutes(ExpiryMinutes);

        public int ExpiryMinutes { get; set; } = 2880; // default to 2 days

        public string Key { get; set; }
    }
}
