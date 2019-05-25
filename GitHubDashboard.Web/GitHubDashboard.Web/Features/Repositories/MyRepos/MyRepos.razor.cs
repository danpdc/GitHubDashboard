using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubDashboard.Web.Features.Repositories.MyRepos
{
    public class MyReposModel : ComponentBase
    {
        [Inject] protected AppState AppState { get; set; }
        [Inject] protected GitHubApiClient ApiClient { get; set; }

        public MyReposModel()
        {
        }

        public List<Repository> MyRepos { get; set; }

        protected async override Task OnInitAsync()
        {
            if(MyRepos == null)
                MyRepos = await ApiClient.GetMyRepositories(AppState.Token);
        }
    }
}
