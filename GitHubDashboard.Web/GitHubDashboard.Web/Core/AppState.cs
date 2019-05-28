using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
//using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Features.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace GitHubDashboard.Web.Core
{
    public class AppState
    {
        private GitHubApiClient _apiClient;
        private ILocalStorageService _storage;
        public AppState(GitHubApiClient apiClient, ILocalStorageService storage)
        {
            _apiClient = apiClient;
            _storage = storage;
            //TryGetToken();
        }

        public bool IsLoggedIn { get; private set; }
        public string Token { get; private set; }
        public User User { get; set; }

        public async Task Login(PostModel model)
        {
            var response = await _apiClient.Login(model);

            if (response.IsSuccessStatusCode)
            {
                await SaveToken(response);
                IsLoggedIn = true;
                User = await _apiClient.GetLoggedInUser(Token);
            }
        }

        public async Task Logout()
        {
            await _storage.RemoveItemAsync("token");
            IsLoggedIn = false;
            User = null;
        }

        public async Task<bool> CheckIfAuthenticated()
        {
            var token = await _storage.GetItemAsync<string>("token");
            if (token != null)
            {
                Token = token;
                User = await _apiClient.GetLoggedInUser(Token);
                return true;
            }
            else
                return false;
        }

        private async Task SaveToken(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jwt = Json.Deserialize<GitHubTokenResponse>(responseContent);
            Token = jwt.access_token;
            await _storage.SetItemAsync("token", jwt.access_token);
            //var token = await _storage.GetItemAsync<string>("token");
        }
    }
}
