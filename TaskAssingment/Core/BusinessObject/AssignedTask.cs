namespace Core.BusinessObject
{
    public class AssignedTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedById { get; set; }
        public string UpdatedByName { get; set; }
        public int UpdatedById { get; set; }
    }
}

