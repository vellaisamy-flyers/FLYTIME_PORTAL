using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using Microsoft.EntityFrameworkCore;

namespace FLYTIME_PORTAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
                _employeeDbContext = employeeDbContext;
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployee()
        {
            var employees = await _employeeDbContext.Employees.Select(x => new EmployeeResponseModel 
            {
                Id = x.Id,
                EmployeeId = x.EmpId,
                Name =x.UserName,
                Team = x.Team,
                Position =x.Position,
                Exprience =x.Exprience,
                JoinDate =x.JoinDate,
                Description =x.JoinDate,
                Status =x.Status,
                
            }).ToListAsync();

            return employees;

           
        }

    }
}
