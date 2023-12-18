namespace FLYTIME_PORTAL.DTO
{
    public class EmployeeResponseModel
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Exprience { get; set; } = string.Empty;
        public string JoinDate { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
