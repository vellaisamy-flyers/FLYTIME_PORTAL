using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLYTIME_PORTAL.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int No_of_projects { get; set; }
        public string Region { get; set; } = string.Empty;        
        public ICollection<Project> Projects { get; set;}
    }
}
