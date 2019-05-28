using System;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;

namespace GitHubDashboard.Web.Shared
{
    public class NavMenuModel : ComponentBase
    {
        [Inject] protected AppState AppState { get; set; }
        [Inject] IUriHelper UriHelper { get; set; }
        public async Task Logout()
        {
            await AppState.Logout();
            UriHelper.NavigateTo("/");
        }
    }
}
