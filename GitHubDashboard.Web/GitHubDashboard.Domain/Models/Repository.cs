using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubDashboard.Domain.Models
{
    public class Repository
    {
        [JsonProperty("open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("has_downloads")]
        public bool HasDownloads { get; set; }

        [JsonProperty("has_pages")]
        public bool HasPages { get; set; }

        [JsonProperty("subscribers_count")]
        public int SubscribersCount { get; set; }

        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        public string Url { get; set; }

        [JsonProperty("clone_url")]
        public string CloneUrl { get; set; }
        public long Size { get; set; }
        public long Id { get; set; }
        public User Owner { get;  set; }
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Homepage { get; set; }
        public string Language { get; set; }
        public bool Private { get; set; }
    }
}
