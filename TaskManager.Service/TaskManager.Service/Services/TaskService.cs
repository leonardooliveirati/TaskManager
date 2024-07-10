using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<TaskEntity> CreateTaskAsync(TaskEntity task)
        {
            var tasks = await _taskRepository.GetTasksByProjectIdAsync(task.ProjectId);
            if (tasks.Count() >= 20)
            {
                throw new InvalidOperationException("Cannot add more than 20 tasks to a project.");
            }

            return await _taskRepository.CreateTaskAsync(task);
        }

        public async Task<TaskEntity> UpdateTaskAsync(TaskEntity task, string updatedBy)
        {
            var existingTask = await _taskRepository.GetByIdAsync(task.Id);
            if (existingTask == null)
            {
                throw new ArgumentException("Task not found.");
            }

            if (existingTask.Priority != task.Priority)
            {
                throw new InvalidOperationException("Priority cannot be changed after the task is created.");
            }

            await _taskRepository.UpdateTaskAsync(task, updatedBy);
            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
