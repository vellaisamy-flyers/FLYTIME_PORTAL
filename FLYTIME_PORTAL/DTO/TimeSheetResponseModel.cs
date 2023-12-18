namespace FLYTIME_PORTAL.DTO
{
    public class TimeSheetResponseModel
    {
        public string EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
    }
}
