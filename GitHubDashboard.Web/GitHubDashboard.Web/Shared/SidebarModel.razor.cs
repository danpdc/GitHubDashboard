using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;

namespace GitHubDashboard.Web.Shared
{
    public class SidebarModel : ComponentBase
    {
        [Inject] protected AppState AppState { get; set; }

        public SidebarModel()
        {
            DashBoardActive = "active";
            ProfileActive = string.Empty;
            ReposActive = string.Empty;
            ActivityActive = string.Empty;
        }

        public string DashBoardActive { get; set; }
        public string ProfileActive { get; set; }
        public string ReposActive { get; set; }
        public string ActivityActive { get; set; }

        protected void SetProfileActive()
        {
            DashBoardActive = string.Empty;
            ProfileActive = "active";
            ReposActive = string.Empty;
            ActivityActive = string.Empty;
        }

        protected void SetDashboardActive()
        {
            DashBoardActive = "active";
            ProfileActive = string.Empty;
            ReposActive = string.Empty;
            ActivityActive = string.Empty;
        }

        protected void SetReposActive()
        {
            DashBoardActive = string.Empty;
            ProfileActive = string.Empty;
            ReposActive = "active";
            ActivityActive = string.Empty;
        }

        protected void SetActivityActive()
        {
            DashBoardActive = string.Empty;
            ProfileActive = string.Empty;
            ReposActive = string.Empty;
            ActivityActive = "active";
        }
    }
}
