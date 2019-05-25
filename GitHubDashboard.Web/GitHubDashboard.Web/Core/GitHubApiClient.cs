using GitHubDashboard.Domain.Models;
using GitHubDashboard.Web.Features.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubDashboard.Web.Core
{
    public class GitHubApiClient
    {
        private HttpClient _client;
        private const string BaseApiUrl = "https://api.github.com/";
        private const string UserEndpoint = "user";
        private const string MyReposEndpoint = "user/repos";
        private const string OneRepoBase = "repos";
        public GitHubApiClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:58022/");
            _client.DefaultRequestHeaders.Add("User-Agent", "Git Dashboard with Blazor");
        }

        public async Task<User> GetLoggedInUser(string token)
        {
            ConfigureClient(token);
            var response = await _client.GetAsync(BaseApiUrl + UserEndpoint);
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);
            return user;
        }

        public async Task<HttpResponseMessage> Login(PostModel model)
        {
            string url = "https://github.com/login/oauth/access_token";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            return await _client.PostAsync(url, content);
        }

        public async Task<List<Repository>> GetMyRepositories(string token)
        {
            if(!_client.DefaultRequestHeaders.TryGetValues("Accept", out IEnumerable<string> value))
            {
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            }

            ConfigureClient(token);
            var response = await _client.GetAsync(BaseApiUrl + MyReposEndpoint + "?visibilit=all&affiliation=owner,collaborator,organization_member");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var repositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                return repositories;
            }
            else
                return new List<Repository>();
        }

        public async Task<Repository> GetRepositoryById(string token, string user, string nodeId)
        {
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            ConfigureClient(token);
            var response = 
                await _client.GetAsync(BaseApiUrl + OneRepoBase + $"/{user}/{nodeId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var repository = JsonConvert.DeserializeObject<Repository>(content);
                return repository;
            }

            return null;
        }

        public async Task<List<Branch>> GetRepositoryBranches(string token, string user, string repo)
        {
            if(!_client.DefaultRequestHeaders.TryGetValues("Accept", out IEnumerable<string> values))
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            ConfigureClient(token);
            var response =
                await _client.GetAsync(BaseApiUrl + OneRepoBase + $"/{user}/{repo}/branches");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<List<Branch>>(content);
                return branches;
            }

            return null;
        }

        public async Task<List<Issue>> GetRepositoryIssues(string token, string user, string repo)
        {
            if (!_client.DefaultRequestHeaders.TryGetValues("Accept", out IEnumerable<string> values))
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
            ConfigureClient(token);
            var response =
                await _client.GetAsync(BaseApiUrl + OneRepoBase + $"/{user}/{repo}/issues");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var issues = JsonConvert.DeserializeObject<List<Issue>>(content);
                return issues;
            }

            return null;
        }

        private void ConfigureClient(string token)
        {
            var authHeader = _client.DefaultRequestHeaders.TryGetValues("Authorization", out IEnumerable<string> value);
            if (!authHeader)
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }

    }
}
