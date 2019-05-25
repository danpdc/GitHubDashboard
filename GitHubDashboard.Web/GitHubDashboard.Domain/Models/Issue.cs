using GitHubDashboard.Domain.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubDashboard.Domain.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        public string Url { get; set; }
        public int Number { get; set; }
        public IssueState State { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IssueUser User { get; set; }
        public List<IssueUser> Assignees { get; set; }
    }
}
