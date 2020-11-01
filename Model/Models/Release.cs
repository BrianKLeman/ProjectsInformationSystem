using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class Release
    {
        public int ReleaseId { get; set; }

        public string Name { get; set; }
        public DateTime? ExpectedReleaseDate { get; set; }
        public DateTime? ActualReleaseDate { get; set; }
        public int ProjectId { get; set; }
        public ICollection<Iteration> Iterations { get; set; }
    }
}
