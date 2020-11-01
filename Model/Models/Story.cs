using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public int? IterationId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? ReleaseId { get; set; }
        public ICollection<StoryTask> Tasks {get;set;}
    }
}
