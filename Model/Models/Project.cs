using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class Project
    {
        public Project()
        {
            CreatedDate = DateTime.Now;
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        
        public int StoryCount
        {
            get
            {
                if (Stories == null)
                    return 0;
                return Stories.Count();
            }
        }
        public ICollection<Release> Releases { get; set; }
        public ICollection<Story> Stories { get; set; }
    }
}
