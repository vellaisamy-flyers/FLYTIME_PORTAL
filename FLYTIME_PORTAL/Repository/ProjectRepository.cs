using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using ProjectRequestModel = FLYTIME_PORTAL.DTO.ProjectRequestModel;

namespace FLYTIME_PORTAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public ProjectRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Project> AddProject(ProjectRequestModel request)
        {
            var userData = new Project
            {
               // Id = request.Id,
                Name = request.Name,
                //No_of_employee = request.No_of_employee,
                Status = request.Status,
                ClientId = request.ClientId,                     
                
            };



           // _employeeDbContext.Employees.Add();
            _employeeDbContext.Projects.Add(userData);
            await _employeeDbContext.SaveChangesAsync();

            var project = _employeeDbContext.Projects.FirstOrDefault(e => e.Name == request.Name);

            var empProjectData = new List<ProjectEmployee>();
            foreach (var emp in request.EmployeeId)
            {
                var empData = new ProjectEmployee
                {
                    // Id = request.Id,
                    EmpId = emp,
                    //No_of_employee = request.No_of_employee,
                    ProjectId = project.Id

                };
                empProjectData.Add(empData);
            }
            _employeeDbContext.ProjectEmployees.AddRange(empProjectData);
            await _employeeDbContext.SaveChangesAsync();

            //   var res = _employeeDbContext.pro

            return userData;
        }

        public async Task<List<ProjectResponseModel>> GetAllProjets()
        {            
            var records = await _employeeDbContext.Projects.//ToListAsync();
            Select(n => new ProjectResponseModel()
            {
                Id = n.Id,
                Name = n.Name,
                ClientId = n.ClientId,
                ClientName = n.Clients.Name,
                Description = n.Description,
                Domain = n.Domain,
               // No_of_employee=n.No_of_employee,
                Status = n.Status,             
            }).ToListAsync();

            return records;

        }

        public async Task<ProjectResponseModel> GetProjectById(int id)
        {
            var recods = await _employeeDbContext.Projects.FindAsync(id);

            return new ProjectResponseModel()
            {
                Id= id,                
                Name = recods.Name,                
                //No_of_employee = recods.No_of_employee,
                Status = recods.Status,
            };

        }

        public async Task<bool> DeleteProject(int id)
        {       
            var record = await _employeeDbContext.Projects.FindAsync(id);
            if (record != null)
            {
                _employeeDbContext.Projects.Remove(record);
                _employeeDbContext.SaveChanges();

                return true;
            }
            return false;

        }

        public async Task<ProjectResponseModel> UpdateProject(int id, ProjectRequestModel requestUser)
        {
            var records = await _employeeDbContext.Projects.FindAsync(id);
            if (records != null)
            {
                records.Name = requestUser.Name;               
                //records.No_of_employee = requestUser.No_of_employee;
                records.Status = requestUser.Status;
                records.Domain = requestUser.Domain;
                records.Description = requestUser.Description;
                records.ClientId = requestUser.ClientId;

                await _employeeDbContext.SaveChangesAsync();
            }
            var responseData = new ProjectResponseModel()
            {
                Name = records.Name,
               // No_of_employee= records.No_of_employee,
                ClientId = records.ClientId,
                Description = records.Description,
                Domain = records.Domain,
                Status = records.Status,               
            };

            return responseData;
        }


       


    }
}
