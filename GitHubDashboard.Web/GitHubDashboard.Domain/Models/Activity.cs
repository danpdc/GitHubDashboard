using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubDashboard.Domain.Models
{
    public class Activity
    {
        public string Type { get; set; }
        public bool Public { get; set; }
        public Repository Repo { get; set; }
        public User Actor { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Id { get; set; }
    }
}
