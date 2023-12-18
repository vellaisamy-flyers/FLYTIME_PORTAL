using FLYTIME_PORTAL.Models;

namespace FLYTIME_PORTAL.DTO
{
    public class ProjectRequestModel
    {
      //  public int Id { get; set; }
        public string Name { get; set; }
       // public int ProjecId { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        
        public string Domain { get; set; } = string.Empty;    
        
        public List<string> EmployeeId { get; set; }

    }
}
