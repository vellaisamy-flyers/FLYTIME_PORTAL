using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FLYTIME_PORTAL.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
                _projectRepository = projectRepository;
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(ProjectRequestModel model)
        {
            var result = await _projectRepository.AddProject(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _projectRepository.GetAllProjets();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectRepository.GetProjectById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectRepository.DeleteProject(id);

            if (result)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProject(int id, ProjectRequestModel model)
        {
            var result = _projectRepository.UpdateProject(id,model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }





    }
}
