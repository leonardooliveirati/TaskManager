using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync();
        Task<ProjectEntity> CreateProjectAsync(ProjectEntity project);
        Task DeleteProjectAsync(int projectId);
    }
}
