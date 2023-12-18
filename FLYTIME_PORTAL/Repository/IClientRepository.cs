using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;

namespace FLYTIME_PORTAL.Repository
{
    public interface IClientRepository
    {
        Task<Client> AddClient(ClientRequestModel requestclient);
        Task<bool> DeleteClient(int id);
        Task<List<ClientResponseModel>> GetAllClient();
        Task<ClientResponseModel> GetClientById(int id);
        Task<ClientResponseModel> UpdateClient(int id, ClientRequestModel requestUser);
    }
}
