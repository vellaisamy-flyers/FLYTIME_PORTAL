using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;

namespace FLYTIME_PORTAL.Repository
{
    public interface IProjectRepository
    {
        Task<Project> AddProject(ProjectRequestModel request);
        Task<bool> DeleteProject(int id);
        Task<List<ProjectResponseModel>> GetAllProjets();
        Task<ProjectResponseModel> GetProjectById(int id);
        Task<ProjectResponseModel> UpdateProject(int id, ProjectRequestModel requestUser);
    }
}
