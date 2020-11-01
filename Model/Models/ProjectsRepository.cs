using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class ProjectsRepository : IProjectsRespository
    {
        ProjectsDbContext _dbContext;
        public ProjectsRepository(ProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProject(Project model)
        {
            _dbContext.Projects.Add(model);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _dbContext.Projects.ToList();
        }

        public IEnumerable<Release> GetReleasesForProject(int projectId)
        {
            var project = GetProjectById(projectId);
            if(project == null)
            {
                return null;
            }
            var releases = project.Releases;
            if (releases == null)
                return null;

            return releases.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _dbContext.Projects.Include(r => r.Releases).Where(p => p.ProjectId == id).FirstOrDefault();
        }

        public void RemoveProject(int id)
        {
            var m = GetProjectById(id);
            if(m!=null)
            {
                _dbContext.Projects.Remove(m);
                _dbContext.SaveChanges();
            }
            
        }

        public void UpdateProject(Project model)
        {
            var project = _dbContext.Projects.Find(model.ProjectId);
            project.Description = model.Description;
            project.Name = model.Name;
            _dbContext.SaveChanges();
        }

        public void AddReleaseForProject(int projectId, Release release)
        {
            Project projectModel = GetProjectById(projectId);
            
            projectModel.Releases.Add(release);
            _dbContext.SaveChanges();
        }


        public void UpdateReleaseForProject(int projectId, Release value)
        {
            Project projectModel = GetProjectById(projectId);
            if (projectModel != null)
            {
                var release = projectModel.Releases.Where(r => r.ReleaseId == value.ReleaseId).FirstOrDefault();
                if(release != null)
                {
                    release.Name = value.Name;
                    release.ActualReleaseDate = value.ActualReleaseDate;
                    release.ExpectedReleaseDate = value.ExpectedReleaseDate;
                    _dbContext.SaveChanges();
                }
            }
        }

        public void DeleteRelease(int projectId, int releaseId)
        {
            var project = GetProjectById(projectId);
            if (project == null)
                return;

            var release = project.Releases.Where(r => r.ReleaseId == releaseId).FirstOrDefault();
            if (release == null)
                return;
            project.Releases.Remove(release);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Story> GetStories(int projectId)
        {
            return _dbContext.Stories.Where(s => s.ProjectId == projectId);
        }

        public void UpdateStory(int storyId, Story story)
        {
            _dbContext.Stories.Update(story);
            _dbContext.SaveChanges();
        }

        public void CreateStory(int projectId, Story story)
        {
            story.ProjectId = projectId;
            _dbContext.Stories.Add(story);
            _dbContext.SaveChanges();
        }

        public void DeleteStory(int storyId)
        {
            _dbContext.Stories.Remove(_dbContext.Stories.Find(storyId));
            _dbContext.SaveChanges();
        }

        public IEnumerable<StoryTask> GetTasks(int storyId)
        {
            var story = _dbContext.Stories.Include(s => s.Tasks).Where(s => s.StoryId == storyId).FirstOrDefault();
            if (story == null)
                return new List<StoryTask>();
            if (story.Tasks.Count == 0)
                return new List<StoryTask>();

            return story.Tasks;

        }

        public void UpdateTask(StoryTask task)
        {
            Story story = GetStory(task.StoryId);
            if (story == null)
                return;
            var storedTask = story.Tasks.Where(t => t.StoryTaskId == task.StoryTaskId).FirstOrDefault();
            if (storedTask == null)
                return;
            storedTask.Name = task.Name;
            storedTask.Status = task.Status;
            storedTask.StoryId = task.StoryId;
            _dbContext.SaveChanges();
        }

        public void CreateTask(int storyId, StoryTask task)
        {
            var story = GetStory(storyId);
            task.StoryId = storyId;
            story.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _dbContext.Tasks.Find(taskId);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
        }

        public Story GetStory(int storyId)
        {
            return _dbContext.Stories.Find(storyId);
        }

        public List<Story> GetStoriesByReleaseId(int releaseId)
        {
            return _dbContext.Stories.Where(x => x.ReleaseId == releaseId).ToList();
        }
    }
}
