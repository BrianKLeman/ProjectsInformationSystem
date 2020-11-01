using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projects.Controllers.Api
{
    [Route("api/Project/{projectId}/Release")]
    public class ReleaseController : Controller
    {
        private Models.IProjectsRespository _repository;

        public ReleaseController(Models.IProjectsRespository repository)
        {
            _repository = repository;
        }


        // GET: api/Release/5
        [HttpGet]
        public IActionResult Get(int projectId)
        {
            return new JsonResult(_repository.GetReleasesForProject(projectId));
        }

        [HttpGet("{releaseId}")]
        public IActionResult Get(int projectId, int releaseId)
        {
            return new JsonResult(_repository.GetReleasesForProject(projectId).Where(r => r.ReleaseId == releaseId).FirstOrDefault());
        }

        [HttpPost]
        public void Post(int projectId, [FromBody]Models.Release value)
        {
            _repository.AddReleaseForProject(projectId, value);
        }

        [HttpPut("{releaseId}")]
        public void Put(int projectId, int releaseId, [FromBody]Models.Release value)
        {
            _repository.UpdateReleaseForProject(projectId, value);
        }
        
        [HttpDelete("{releaseId}")]
        public void Delete(int projectId, int releaseId)
        {
            _repository.DeleteRelease(projectId, releaseId);
        }
    }
}
