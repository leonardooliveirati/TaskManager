﻿using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskEntity> CreateTaskAsync(TaskEntity task);
        Task<TaskEntity> GetByIdAsync(int id);
        Task<TaskEntity> UpdateTaskAsync(TaskEntity task, string updatedBy);
        Task DeleteTaskAsync(int id);
    }
}
