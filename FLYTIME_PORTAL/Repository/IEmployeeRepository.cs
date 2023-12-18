using FLYTIME_PORTAL.DTO;

namespace FLYTIME_PORTAL.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponseModel>> GetAllEmployee();
    }
}
