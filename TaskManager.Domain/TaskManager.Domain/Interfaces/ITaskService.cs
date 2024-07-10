using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskEntity> CreateTaskAsync(TaskEntity task);
        Task<TaskEntity> UpdateTaskAsync(TaskEntity task, string updatedBy);
        Task DeleteTaskAsync(int id);
    }
}
