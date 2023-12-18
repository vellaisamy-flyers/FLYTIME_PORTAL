using FLYTIME_PORTAL.DbContext;
using FLYTIME_PORTAL.DTO;
using FLYTIME_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace FLYTIME_PORTAL.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public ClientRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Client> AddClient(ClientRequestModel requestclient)
        {
            var userData = new Client
            {
                Name = requestclient.Name,
                No_of_projects = requestclient.No_of_projects,
                Region = requestclient.Region,
            };

            _employeeDbContext.Clients.Add(userData);
            await _employeeDbContext.SaveChangesAsync();
            return userData;
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var recods = await _employeeDbContext.Clients.FindAsync(id);

            if(recods != null)
            {
                var result = new ClientResponseModel()
                {
                    Id = recods.Id,
                    Name = recods.Name,
                    No_of_projects = recods.No_of_projects,
                    Region = recods.Region,
                }; return result;
            }

            return null;

        }

        public async Task<List<ClientResponseModel>> GetAllClient()
        {
            var records = await _employeeDbContext.Clients.
                Select(n => new ClientResponseModel()
                {
                    Id = n.Id,
                    Name = n.Name,
                    No_of_projects = n.No_of_projects,         
                    Region = n.Region,
                }).ToListAsync();
            if(records != null)
            {
                return records;
            }

            return null;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _employeeDbContext.Clients.FindAsync(id);
            if (client != null)
            {
                _employeeDbContext.Remove(client);
                await _employeeDbContext.SaveChangesAsync();  
                
                return true;
            }
            return false;               

        }

        public async Task<ClientResponseModel> UpdateClient(int id, ClientRequestModel requestUser)
        {
            var records = await _employeeDbContext.Clients.FindAsync(id);
            if (records != null)
            {
                records.Name = requestUser.Name != null ? requestUser.Name : records.Name;
                //records.cl = requestUser.Projects;
                records.No_of_projects = requestUser.No_of_projects != null ? requestUser.No_of_projects : records.No_of_projects ;
                records.Region = requestUser.Region != null ? requestUser.Region : records.Region;

                await _employeeDbContext.SaveChangesAsync();

                var responseData = new ClientResponseModel()
                {
                    Name = records.Name,
                    Region = records.Region,
                    No_of_projects = records.No_of_projects
                };

                return responseData;
            }           

            return null;
        }


    }
}