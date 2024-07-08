using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEntity> CreateProjectAsync(ProjectEntity project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.Include(p => p.Tasks)
                                             .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null || project.Tasks.Any(t => t.Status != "Completed"))
            {
                throw new InvalidOperationException("Cannot delete project with pending tasks.");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync();
        }
    }
}
