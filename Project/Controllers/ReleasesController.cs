using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using WebService.ViewModel;
namespace Projects.Controllers
{
    public class ReleasesController : Controller
    {
        private IProjectsRespository _repository;

        public ReleasesController(IProjectsRespository repository)
        {
            _repository = repository;
        }

        [Route("/Releases/{projectId:int}")]
        [HttpGet()]
        public IActionResult Index(int projectId)
        {

            return View(new ReleasesSummary
            {
                ProjectModel = _repository.GetProjectById(projectId),
                Releases = _repository.GetReleasesForProject(projectId)?.ToList() ?? new List<Release>()
            });
        }

        [HttpPost]
        [Route("/Releases/{projectId:int}/delete/{releaseID:int}")]
        public IActionResult Delete(int projectId, int releaseID)
        {
            _repository.DeleteRelease(projectId, releaseID);
            return RedirectToAction(nameof(Index));
        }

        [Route("/Releases/{projectId:int}/create/")]
        public ViewResult Create(int projectId)
        {
            return View(new Release() { ProjectId = projectId });
        }

        [HttpPost]
        public RedirectToActionResult AddRelease(Release release)
        {
            _repository.AddReleaseForProject(release.ProjectId, release);
            return RedirectToAction(nameof(Index), new { projectId = release.ProjectId });
        }
        
        [HttpGet]
        public ViewResult Edit(int projectId, int releaseId)
        {
            return View(new ReleaseWithStories()
            {
                Release = _repository.GetReleasesForProject(projectId).FirstOrDefault(x => x.ReleaseId == releaseId),
                ProjectModel = _repository.GetProjectById(projectId),
                Stories = _repository.GetStoriesByReleaseId(releaseId)
            });
        }

        [HttpPost]
        public RedirectToActionResult Edit(Release release)
        {
            _repository.UpdateReleaseForProject(release.ProjectId, release);
            return RedirectToAction(nameof(Index), new { projectId = release.ProjectId });
        }
    }
}