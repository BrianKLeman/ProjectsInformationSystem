using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using WebService.ViewModel;
namespace Projects.Controllers
{
    public class AppController : Controller
    {
        private IProjectsRespository _repository;

        public AppController(IProjectsRespository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {

            return View(_repository.GetAllProjects().Select( p => new ProjectSummary
            {
                ProjectModel = p,
                StoryCount = _repository.GetStories(p.ProjectId).Count(),
                ReleaseCount = _repository.GetReleasesForProject(p.ProjectId).Count()
            }));
        }

        [HttpPost]
        public RedirectToActionResult CreateProject(Project project)
        {
            _repository.AddProject(project);
            return RedirectToAction(nameof(Index));
        }
        
        public ViewResult Create()
        {
            return View();
        }
    }
}