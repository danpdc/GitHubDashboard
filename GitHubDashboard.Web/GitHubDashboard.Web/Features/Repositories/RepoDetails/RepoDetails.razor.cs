using Microsoft.AspNetCore.Components;
using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubDashboard.Web.Features.Repositories.RepoDetails
{
    public class RepoDetailsModel : ComponentBase
    {
        [Parameter] private string Name { get; set; }
        [Inject] protected AppState AppState { get; set; }
        [Inject] protected GitHubApiClient ApiClient { get; set; }

        public RepoDetailsModel()
        {
            BranchesActive = "active";
            IssuesActive = string.Empty;
            DataLoaded = false;
        }
        protected string BranchesActive { get; set; }
        protected string IssuesActive { get; set; }

        protected List<Branch> Branches { get; set; }
        protected List<Issue> Issues { get; set; }
        protected Repository Repo { get; set; }
        protected bool DataLoaded { get; set; }

        protected async override Task OnInitAsync()
        {
            if (Repo == null)
                Repo = await ApiClient.GetRepositoryById(AppState.Token, AppState.User.Login, Name);
            if(Branches == null)
                Branches = await ApiClient.GetRepositoryBranches(AppState.Token, AppState.User.Login, Name);
            if(Issues == null)
               Issues = await ApiClient.GetRepositoryIssues(AppState.Token, AppState.User.Login, Name);

            DataLoaded = true;
        }

        protected void ActivateBranches()
        {
            BranchesActive = "active";
            IssuesActive = string.Empty;
        }

        protected void ActivateIssues()
        {
            BranchesActive = string.Empty;
            IssuesActive = "active";
        }
    }
}
