
using System.ComponentModel.DataAnnotations;

namespace FLYTIME_PORTAL.DTO
{
    public class Login
    {
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
