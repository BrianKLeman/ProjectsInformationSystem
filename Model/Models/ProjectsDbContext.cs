using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class ProjectsDbContext : DbContext
    {
        IConfigurationRoot _configRoot;

        public ProjectsDbContext(IConfigurationRoot configRoot, DbContextOptions contextOptions)
           : base(contextOptions)
        {
            _configRoot = configRoot;

        }

        public ProjectsDbContext()
            :base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer("Server=lounge-pc;Database=projects;MultipleActiveResultSets=True; User=defaultuser; Password=pwd123;"/*_configRoot["ConnectionStrings:Default"]*/);
        }

        public DbSet<Models.Project> Projects { get; set; }
        public DbSet<Models.Story> Stories { get; set; }
        public DbSet<Models.StoryTask> Tasks { get; set; }
    }
}
