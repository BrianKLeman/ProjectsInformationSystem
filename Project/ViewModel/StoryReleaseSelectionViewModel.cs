using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModel
{
    public class StoryReleaseSelectionViewModel
    {
        public IEnumerable<Release> Releases { get; set; }
        public int selectedReleaseID { get; set; }
    }
}
