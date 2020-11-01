using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class Iteration
    {
        public int IterationId { get; set; }
        public string CreatedDate { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
