namespace TaskManager.Domain.Entities
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
