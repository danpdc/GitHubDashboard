using System;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;

namespace GitHubDashboard.Web.Features.Layout
{
    public class MainLayoutModel : LayoutComponentBase
    {
        [Inject] protected AppState AppState { get; set; }
        public MainLayoutModel()
        {
            CurrentYear = DateTime.Now.Year.ToString();
            IsAuthenticated = false;
            AuthCheckProcessCompleted = false;
        }
        public string CurrentYear { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool AuthCheckProcessCompleted { get; set; }

        protected async override Task OnAfterRenderAsync()
        {
            IsAuthenticated = await AppState.CheckIfAuthenticated();
            AuthCheckProcessCompleted = true;
            StateHasChanged();
        }

    }
}
