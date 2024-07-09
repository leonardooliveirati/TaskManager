using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
