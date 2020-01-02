using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighChartApp.Api.Models
{
    public class TokenResult
    {
        public string access_token { get; set; }
        public string token_type { get { return "bearer"; } }
        public int expires_in { get; set; }
    }
}
