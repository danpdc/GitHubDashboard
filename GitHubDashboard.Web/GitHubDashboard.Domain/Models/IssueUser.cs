using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubDashboard.Domain.Models
{
    public class IssueUser
    {
        public string Login { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
