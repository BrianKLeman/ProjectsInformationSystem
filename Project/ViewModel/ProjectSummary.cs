using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projects.Models;
namespace WebService.ViewModel
{
    public class ProjectSummary
    {
        public Project ProjectModel { get; set; }

        public int StoryCount { get; set; }

        public int ReleaseCount { get; set; }
    }
}
