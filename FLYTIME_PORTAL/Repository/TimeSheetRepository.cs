using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

namespace FLYTIME_PORTAL.Repository
{
    public class TimeSheetRepository : ITimeSheeRepository
    {
        public readonly EmployeeDbContext _employeeDbContext;

        public TimeSheetRepository(EmployeeDbContext employeeDbContex)
        {
                _employeeDbContext = employeeDbContex;
        }

        public async Task<TimeSheet> AddTimeSheet(TimeSheetResquestModel request)
        {
            var timeData = new TimeSheet
            {
                ProjectId = request.ProjectId,
                EmployeeId = request.EmployeeId,
                TaskName = request.TaskName,
                Date = request.Date,
                Hours = request.Hours,
                Status = request.Status,
                Comments = request.Comments
            };

           _employeeDbContext.TimeSheets.Add(timeData);
            await _employeeDbContext.SaveChangesAsync();
            return timeData;
        }

        public async Task<List<TimeSheetResponseModel>> GetAllTimeSheets()
        {
            
            var records = await _employeeDbContext.TimeSheets.//.ToListAsync();
            Select(n => new TimeSheetResponseModel()
            {
             EmployeeId = n.EmployeeId, 
             TaskName = n.TaskName,
             //ClientName = n.Projects.Clients.Name,
           //  ProjectName = n.Projects.Name,
             Date = n.Date,
             Hours = n.Hours,
             Comments = n.Comments,
             Status = n.Status
             
            }).ToListAsync();
            return records;
        }

        public async Task<TimeSheetResponseModel> GetTimeSheetById(int id)
        {
            var recods = await _employeeDbContext.TimeSheets.FindAsync(id);
           // var projetName = await _employeeDbContext.Projects.FindAsync(recods.ProjectId);
           // var clientNmae = await _employeeDbContext.Clients.FindAsync(projetName.ClientId);
            return new TimeSheetResponseModel()
            {
                TaskName = recods.TaskName,
                EmployeeId = recods.EmployeeId,
                Date = recods.Date,
                Hours = recods.Hours,
                Comments = recods.Comments,
               // ProjectName = projetName.Name,
             //   ClientName = clientNmae.Name

            };
        }


        public async Task<bool> DeleteTimeSheet(int id)
        {
            var record = await _employeeDbContext.TimeSheets.FindAsync(id);
            if (record != null)
            {
                _employeeDbContext.TimeSheets.Remove(record);
                _employeeDbContext.SaveChanges();

                return true;
            }
            return false;
        }

        


    }
}
