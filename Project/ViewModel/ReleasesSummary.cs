using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projects.Models;
namespace WebService.ViewModel
{
    public class ReleasesSummary
    {
        public Project ProjectModel { get; set; }

        public List<Release> Releases { get; set; }        
    }
}
