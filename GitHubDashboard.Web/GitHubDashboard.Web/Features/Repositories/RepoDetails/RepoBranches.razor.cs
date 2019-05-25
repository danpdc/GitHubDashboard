using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubDashboard.Web.Features.Repositories.RepoDetails
{
    public class RepoBranchesModel : ComponentBase
    {
        [Parameter] protected List<Branch> Branches { get; set; }
        [Inject] protected AppState AppState { get; set; }
        [Inject] protected GitHubApiClient ApiClient { get; set; }

    }
}
