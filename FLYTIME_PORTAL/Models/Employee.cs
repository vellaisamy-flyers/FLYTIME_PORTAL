using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FLYTIME_PORTAL.Models
{
    [Index(nameof(EmpId), IsUnique = true)]
    public class Employee :IdentityUser
    {
      
        [Required]       
        public string EmpId { get; set; }       
        public string Team { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Exprience { get; set; } = string.Empty;
        public string JoinDate { get; set; } = string.Empty;
        public bool Status { get; set; } 
        
        public ICollection<TimeSheet> TimeSheets { get; } = new List<TimeSheet>();


      

    }
}
