using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projects.Models;
namespace WebService.ViewModel
{
    public class StoriesSummary
    {
        public Project ProjectModel { get; set; }

        public List<Story> Stories { get; set; }        
    }
}
