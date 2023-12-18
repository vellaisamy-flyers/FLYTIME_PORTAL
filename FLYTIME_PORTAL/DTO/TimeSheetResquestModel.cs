namespace FLYTIME_PORTAL.DTO
{
    public class TimeSheetResquestModel
    {
        public int ProjectId { get; set; }
        public string EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        

    }
}
