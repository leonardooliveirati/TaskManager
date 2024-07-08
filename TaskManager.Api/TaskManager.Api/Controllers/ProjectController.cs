
using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Dtos;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();

            var projectDtos = projects.Select(project => new ProjectDto
            {
                Id = project.Id,
                Name = project.Name
            });

            return Ok(projectDtos);
            
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Ocorreu um erro interno no servidor. Tente novamente mais tarde." });
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreateProjectDto>> CreateProject(CreateProjectDto createProjectDto)
    {
        if (createProjectDto == null) {
            return BadRequest(new { error = "A solicitação é inválida." });
        }

        try
        {
            var project = new ProjectEntity
            {
                Name = createProjectDto.Name,
            };

            var createdProject = await _projectService.CreateProjectAsync(project);
            var result = CreatedAtAction(nameof(GetProjects), new { id = createdProject.Id }, createdProject);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Ocorreu um erro interno no servidor. Tente novamente mais tarde." });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        try
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
