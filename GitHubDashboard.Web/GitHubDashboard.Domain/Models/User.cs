using GitHubDashboard.Domain.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubDashboard.Domain.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int? Collaborators { get; set; }
        public string Blog { get; set; }
        public string Bio { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        public int TotalPrivateRepos { get; set; }
        public AccountType? Type { get; set; }
    }
}
