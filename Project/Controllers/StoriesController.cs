using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using WebService.ViewModel;
namespace Projects.Controllers
{
    public class StoriesController : Controller
    {
        private IProjectsRespository _repository;

        public StoriesController(IProjectsRespository repository)
        {
            _repository = repository;
        }

        [Route("/Stories/{projectId:int}")]
        [HttpGet()]
        public IActionResult Index(int projectId)
        {

            return View(new StoriesSummary
            {
                ProjectModel = _repository.GetProjectById(projectId),
                Stories = _repository.GetStories(projectId)?.ToList() ?? new List<Story>()
            });
        }

        [Route("/Stories/{projectId:int}/delete/{storyID}")]
        public IActionResult Delete(int projectId, int storyID)
        {
            _repository.DeleteStory(storyID);
            return Redirect($"/Stories/{projectId}");
        }
        
        [Route("/Stories/{projectId:int}/create/")]
        public ViewResult Create(int projectId)
        {
            return View(new Story { ProjectId = projectId });
        }

        [HttpPost]
        public RedirectToActionResult AddStory(Story story)
        {
            _repository.CreateStory(story.ProjectId, story);
            return RedirectToAction(nameof(Index), new { projectId = story.ProjectId });
        }

        [HttpGet]
        public ViewResult Edit(int storyId)
        {
            return View(_repository.GetStory(storyId));
        }

        [HttpPost]
        public RedirectToActionResult Edit(Story story)
        {
            _repository.UpdateStory(story.StoryId, story);
            return RedirectToAction(nameof(Index), new { projectId = story.ProjectId });
        }
    }
}