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
    [Route("api/Projects/{ProjectId}/Stories/{storyId}/Tasks")]
    public class TaskController : Controller
    {
        private IProjectsRespository _repository;

        public TaskController(IProjectsRespository projectsRepository)
        {
            _repository = projectsRepository;
        }
        // GET: api/Task
        [HttpGet]
        public IEnumerable<Models.StoryTask> Get(int storyId)
        {
            return _repository.GetTasks(storyId);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public Models.StoryTask Get(int storyId, int id)
        {
            var tasks = _repository.GetTasks(storyId);
            return tasks.Where(t => t.StoryTaskId == id).FirstOrDefault();
        }
        
        // POST: api/Task
        [HttpPost]
        public void Post(int storyId, [FromBody]Models.StoryTask value)
        {
            _repository.CreateTask(storyId, value);
        }
        
        // PUT: api/Task/5
        [HttpPut]
        public void Put([FromBody]Models.StoryTask value)
        {
            _repository.UpdateTask(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteTask(id);
        }
    }
}
