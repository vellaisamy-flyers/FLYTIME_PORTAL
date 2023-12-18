using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using FLYTIME_PORTAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FLYTIME_PORTAL.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        // private readonly IConfiguration _configuration;
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager,
             EmployeeDbContext employeeDbContext, IEmployeeRepository employeeRepository)
        {
            //_configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _employeeDbContext = employeeDbContext;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("Rigister")]
        public async Task<IActionResult> Register(Register model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Name);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "false", Message = "user" });
            }

            Employee user = new Employee
            {
                UserName = model.Name,
                Email = model.Email,
                EmpId = model.EmpId,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "false", Message = "user" });
            }

            if (await _roleManager.RoleExistsAsync(Roles.Employee))
            {
                await _userManager.AddToRoleAsync(user, Roles.Employee);
            }

            return Ok(new Response { Status = "200", Message = "User Created Successfully " });
        }
        
        [HttpGet("GetAll")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeRepository.GetAllEmployee();
           
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

       

    }
}
