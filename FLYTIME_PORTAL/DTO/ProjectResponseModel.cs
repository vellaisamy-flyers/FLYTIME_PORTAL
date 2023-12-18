namespace FLYTIME_PORTAL.DTO
{
    public class ProjectResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int No_of_employee { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Domain { get; set; } = string.Empty;
    }
}
