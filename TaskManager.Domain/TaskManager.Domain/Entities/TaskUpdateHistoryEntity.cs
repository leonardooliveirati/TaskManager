namespace TaskManager.Domain.Entities
{
    public class TaskUpdateHistoryEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string UpdateDescription { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
