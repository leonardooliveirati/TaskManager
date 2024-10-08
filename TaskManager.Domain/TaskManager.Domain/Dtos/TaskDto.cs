﻿using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
