using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projects.Models;
namespace WebService.ViewModel
{
    public class ReleaseWithStories
    {
        public Project ProjectModel { get; set; }
        public Release Release { get; set; }

        public List<Story> Stories { get; set; }        
    }
}
