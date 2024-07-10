using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Dtos
{
    public class CreateTaskDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
