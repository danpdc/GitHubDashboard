using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubDashboard.Web.Features.Login
{
    public class PostModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string code { get; set; }
    }
}
