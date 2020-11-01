using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.ViewModel;

namespace WebService.Components
{
    public class StoryReleasesSelectionViewComponent : ViewComponent
    {
        private IProjectsRespository _respository;
        public StoryReleasesSelectionViewComponent(IProjectsRespository projectsRespository)
        {
            _respository = projectsRespository;
        }
        public IViewComponentResult Invoke(Story story)
        {
             return View(new StoryReleaseSelectionViewModel() { Releases = _respository.GetReleasesForProject(story.ProjectId), selectedReleaseID = story.ReleaseId ?? 0 });
        }
    }
}
