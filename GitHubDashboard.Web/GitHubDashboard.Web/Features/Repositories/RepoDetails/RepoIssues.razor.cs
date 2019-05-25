using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubDashboard.Web.Features.Repositories.RepoDetails
{
    public class RepoIssuesModel : ComponentBase
    {
        [Parameter] protected List<Issue> Issues { get; set; }
        [Inject] protected AppState AppState { get; set; }
        [Inject] protected GitHubApiClient ApiClient { get; set; }
    }
}
