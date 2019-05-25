using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;

namespace GitHubDashboard.Web.Features.Profile
{
    public class ProfileModel : ComponentBase
    {
        [Inject] protected AppState AppState { get; set; }
    }
}
