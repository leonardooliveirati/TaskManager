using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;

        public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }

        public async Task<ProjectEntity> CreateProjectAsync(ProjectEntity project)
        {
            return await _projectRepository.CreateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var tasks = await _taskRepository.GetTasksByProjectIdAsync(projectId);
            if (tasks.Any(t => t.Status != "Completo"))
            {
                throw new InvalidOperationException("Cannot delete project with pending tasks. Complete or remove the tasks first.");
            }

            await _projectRepository.DeleteProjectAsync(projectId);
        }
    }
}
