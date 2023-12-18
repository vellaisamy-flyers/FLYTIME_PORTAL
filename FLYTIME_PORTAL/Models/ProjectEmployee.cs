using System.ComponentModel.DataAnnotations;

namespace FLYTIME_PORTAL.Models
{
    public class ProjectEmployee
    {
        [Key]
        public int Id { get; set; }        
        public int ProjectId { get; set; }       
        public string EmpId { get; set; }

    }
}
