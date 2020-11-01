using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class StoryTask
    {
        public int StoryTaskId { get; set; }
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

    }
}
