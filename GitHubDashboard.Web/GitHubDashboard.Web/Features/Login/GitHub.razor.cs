using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GitHubDashboard.Web.Core;
using GitHubDashboard.Web.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace GitHubDashboard.Web.Features.Login
{
    public class GitHubModel : ComponentBase
    {
        [Inject] IUriHelper UriHelper { get; set; }
        [Inject] AppState AppState { get; set; }
        [Inject] IOptions<GitHubAuthSettings> AuthSettings { get; set; }

        protected async override Task OnAfterRenderAsync()
        {
            var uri = new Uri(UriHelper.GetAbsoluteUri());
            var code = ParseQuery(uri);
            var postModel = CreatePostModel(code);
            await AppState.Login(postModel);
            UriHelper.NavigateTo("/");
        }

        private string ParseQuery(Uri uri)
        {
            var queryDictionary = QueryHelpers.ParseQuery(uri.Query);
            StringValues code;
            queryDictionary.TryGetValue("code", out code);
            return code.ToString();
        }

        private PostModel CreatePostModel(string code)
        {
            return new PostModel
            {
                client_id = AuthSettings.Value.ClientId,
                client_secret = AuthSettings.Value.ClientSecret,
                code = code
            };
        }
    }
}
