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
        }
        public string CurrentYear { get; set; }

    }
}
