using System;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using GitHubDashboard.Web.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace GitHubDashboard.Web.Features.Login
{
    public class LoginModel : ComponentBase
    {
        [Inject] private AppState AppState { get; set; }
        [Inject] IOptions<GitHubAuthSettings> AuthSettings { get; set; }
        public LoginModel()
        {
            CurrentYear = DateTime.Now.Year.ToString();
        }
        public string CurrentYear { get; set; }
        public string ClientId => AuthSettings.Value.ClientId;
        public string ClientSecret => AuthSettings.Value.ClientSecret;
        public string AuthorizeUrl => $"https://github.com/login/oauth/authorize?client_id=" + ClientId + "&scope=user%20repo%20notifications";

    }
}
