using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Models
{
    public interface IProjectsRespository
    {
        IEnumerable<Project> GetAllProjects();

        void UpdateProject(Project model);

        Project GetProjectById(int id);

        void AddProject(Project model);

        void RemoveProject(int id);

        IEnumerable<Release> GetReleasesForProject(int projectId);

        void AddReleaseForProject(int projectId, Release release);
        void UpdateReleaseForProject(int projectId, Release value);
        void DeleteRelease(int projectId, int releaseId);

        IEnumerable<Story> GetStories(int projectId);
        void UpdateStory(int storyId, Story story);
        void CreateStory(int projectId, Story story);
        void DeleteStory(int storyId);
        Story GetStory(int storyId);

        IEnumerable<StoryTask> GetTasks(int story);
        void UpdateTask(StoryTask task);
        void CreateTask(int storyId, StoryTask task);
        void DeleteTask(int taskId);
        List<Story> GetStoriesByReleaseId(int releaseId);
    }
}
