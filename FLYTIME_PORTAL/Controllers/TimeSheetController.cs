using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using FLYTIME_PORTAL.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FLYTIME_PORTAL.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class TimeSheetController : ControllerBase
    {

        private readonly ITimeSheeRepository _timeSheeRepository;
        private readonly EmployeeDbContext _employeeDbContext;
        public TimeSheetController(ITimeSheeRepository timeSheeRepository , EmployeeDbContext employeeDbContext)
        {
            _timeSheeRepository = timeSheeRepository;
            _employeeDbContext = employeeDbContext;   
        }

        [HttpPost("AddTimeSheet")]
        public async Task<IActionResult> AddTimeSheet(TimeSheetResquestModel model)
        {
            var result = await _timeSheeRepository.AddTimeSheet(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _timeSheeRepository.GetAllTimeSheets();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetTimeSheetById(int id)
        {
            var result = await _timeSheeRepository.GetTimeSheetById(id);

            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();    
        }

        [HttpDelete("DeleteTimeSheet")]
        public async Task<IActionResult> DeleteTimeSheet(int id)
        {
            var result = await _timeSheeRepository.DeleteTimeSheet(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("GetProjectWiseEMployee")]
        public async Task<IActionResult> GetAllClients(int projectid, string empid, DateTime fromDate, DateTime toDate)
        {

           // var project = await _employeeDbContext.Projects.Where(x => x.Id == projectid).ToListAsync();

            var timesheet = await _employeeDbContext.TimeSheets.Where(x=> x.ProjectId == projectid && x.EmployeeId == empid && x.Date >=  fromDate && x.Date <= toDate ).ToListAsync();

           
            return Ok(timesheet);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpTimeSheet(string empid)
        {
            var timesheet = await _employeeDbContext.TimeSheets.Where(x => x.EmployeeId == empid).ToListAsync();

            return Ok(timesheet);
        }



    }
}
