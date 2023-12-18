using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLYTIME_PORTAL.Models
{
    public class TimeSheet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employees")]
        public string EmployeeId { get; set; }
        
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        //[ForeignKey("EmployeeId")]
        public virtual Employee Employees { get; set; }
        public virtual Project Projects { get; set; }

    }
}
