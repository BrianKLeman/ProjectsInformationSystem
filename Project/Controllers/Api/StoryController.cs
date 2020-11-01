using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;

namespace Projects.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Projects/{projectId}/Stories")]
    public class StoryController : Controller
    {
        IProjectsRespository _repository;
        public StoryController(IProjectsRespository projectsRepository)
        {
            _repository = projectsRepository;
        }

        [HttpGet]
        public IEnumerable<Story> Get(int projectId)
        {
            return _repository.GetStories(projectId);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int projectId, int id)
        {
            return new JsonResult(_repository.GetStory(id));
        }
        

        [HttpPost("redirect")]
        public void Post(int projectId, [FromBody]string value)
        {
            Console.WriteLine(value);
        }

        [HttpPost]
        public void Post(int projectId, [FromBody]Story value)
        {
            _repository.CreateStory(projectId, value);
        }
        [HttpPut("{id}")]
        public void Put(int projectId, int id, [FromBody]Story value)
        {
            _repository.UpdateStory(id, value);
        }
        

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteStory(id);
        }
    }
}
