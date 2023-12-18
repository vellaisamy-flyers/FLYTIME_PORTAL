using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLYTIME_PORTAL.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Clients")]
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
       // public int No_of_employee {  get; set; }
        public string Status { get; set; } = string.Empty;      
        public string Description { get; set; } = string.Empty;
        public ICollection<TimeSheet> TimeSheets { get; set; }
        public Client Clients { get; set; } 
    }
}
