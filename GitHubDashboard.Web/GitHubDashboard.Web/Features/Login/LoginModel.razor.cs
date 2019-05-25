using System;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;

namespace GitHubDashboard.Web.Features.Login
{
    public class LoginModel : ComponentBase
    {
        [Inject] private AppState AppState { get; set; }
        public LoginModel()
        {
            CurrentYear = DateTime.Now.Year.ToString();
        }
        public string CurrentYear { get; set; }

    }
}
