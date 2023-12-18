using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using FLYTIME_PORTAL.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualBasic;

namespace FLYTIME_PORTAL.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientErrorActionResult)
        {
            _clientRepository = clientErrorActionResult;
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient(ClientRequestModel model )
        {
            var result = await _clientRepository.AddClient(model);
            if (result != null )
            {
                return Ok(result);
            }
            return BadRequest();
           
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientRepository.GetAllClient();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _clientRepository.GetClientById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = _clientRepository.DeleteClient(id);
            if (result != null)
            {
                return Ok(result);
            }


            return BadRequest();
           
        }

        [HttpPost("UpdateClient")]
        public async Task<IActionResult> UpdateClient(int id, ClientRequestModel model)
        {
            var result = _clientRepository.UpdateClient(id, model);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}
