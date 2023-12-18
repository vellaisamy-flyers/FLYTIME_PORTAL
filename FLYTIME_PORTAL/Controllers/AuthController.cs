using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FLYTIME_PORTAL.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("Seed-Roles")]
        public async Task<IActionResult> CreateRoles()
        {
            bool isAdminExists = await _roleManager.RoleExistsAsync(Roles.Admin);
            bool isUserExists = await _roleManager.RoleExistsAsync(Roles.Employee);

            if (isAdminExists && isUserExists)
            {
                return Ok("Admin and user role is alredy exist ");
            }
            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            await _roleManager.CreateAsync(new IdentityRole(Roles.Employee));
            return Ok("admin and user role added successfully..!");

        }

        [HttpPost]
        [Route("Employee")]
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


        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(Register model)
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
                EmpId =model.EmpId,
                SecurityStamp = Guid.NewGuid().ToString(),

            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "false", Message = "user" });
            }

            if (await _roleManager.RoleExistsAsync(Roles.Admin))
            {
                await _userManager.AddToRoleAsync(user, Roles.Admin);
            }
            return Ok(new Response { Status = "200", Message = "Admin Created Successfully " });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    
                };

                foreach (var userRole in userRoles)
                {
                    authClims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );

                var role = _roleManager.Roles.FirstOrDefault();
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    user = user.UserName,
                    empId = user.EmpId,
                    name = user.UserName,
                    id = user.Id,
                    role = userRoles[0],
                                    


                });
            }
            return Unauthorized();

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUsers(string id)
        {
            var res = await _userManager.FindByIdAsync(id);

            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);

        }
    }
}
