namespace TaskManager.Domain.Entities
{
    public class TaskCommentEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentedBy { get; set; }
    }
}
