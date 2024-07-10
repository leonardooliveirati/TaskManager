using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TaskEntity> CreateTaskAsync(TaskEntity task)
        {
            var project = await _context.Projects.Include(p => p.Tasks)
                                             .FirstOrDefaultAsync(p => p.Id == task.ProjectId);

            if (project.Tasks.Count >= 20)
            {
                throw new InvalidOperationException("Task limit exceeded for the project.");
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<TaskEntity> UpdateTaskAsync(TaskEntity task, string updatedBy)
        {
            var existingTask = await _context.Tasks.FindAsync(task.Id);
            if (existingTask == null) throw new KeyNotFoundException("Task not found.");

            _context.Entry(existingTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var updateHistory = new TaskUpdateHistoryEntity
            {
                TaskId = task.Id,
                UpdateDescription = $"Task updated: {task.Title}",
                UpdateDate = DateTime.Now,
                UpdatedBy = updatedBy
            };

            _context.TaskUpdateHistory.Add(updateHistory);
            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
