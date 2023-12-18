using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;

namespace FLYTIME_PORTAL.Repository
{
    public interface ITimeSheeRepository
    {
        Task<TimeSheet> AddTimeSheet(TimeSheetResquestModel request);
        Task<bool> DeleteTimeSheet(int id);
        Task<List<TimeSheetResponseModel>> GetAllTimeSheets();
        Task<TimeSheetResponseModel> GetTimeSheetById(int id);
    }
}
