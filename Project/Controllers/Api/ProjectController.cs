using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Controllers.Api
{
    [Route("/Api/Project")]
    public class ProjectController
    {
        private Models.IProjectsRespository _projectsRepository;

        public ProjectController(Models.IProjectsRespository projectRepository)
        {
            _projectsRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_projectsRepository.GetAllProjects());
        }

        [HttpGet("/Api/Project/{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_projectsRepository.GetProjectById(id));
        }
       

        [HttpPut]
        public IActionResult Update([FromBody]Models.Project updatedProject)
        {
            _projectsRepository.UpdateProject(updatedProject);
            return new OkResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Models.Project createdProject)
        {
            _projectsRepository.AddProject(createdProject);
            
            return new OkResult();
        }

        [HttpDelete("/Api/Project/{id}")]
        public IActionResult Delete(int id)
        {
            _projectsRepository.RemoveProject(id);
            return new OkResult();
        }
    }
}
