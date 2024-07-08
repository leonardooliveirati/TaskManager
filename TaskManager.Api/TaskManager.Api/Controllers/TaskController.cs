using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Dtos;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    [HttpGet("{projectId:int}")]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks(int projectId)
    {
        if (projectId <= 0)
        {
            return BadRequest(new { error = "Invalid project ID." });
        }

        try
        {
            var tasks = await _taskService.GetTasksByProjectIdAsync(projectId);
            var taskDtos = tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                Title = task.Title,
                Description = task.Description,                
                Status = task.Status,
                Priority = task.Priority
            });

            return Ok(taskDtos);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "An internal server error occurred. Please try again later." });
        }
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
    {
        if (createTaskDto == null)
        {
            return BadRequest(new { error = "Invalid task data." });
        }

        try
        {
            var task = new TaskEntity
            {
                ProjectId = createTaskDto.ProjectId,
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,                
                Status = "Pending",
                Priority = createTaskDto.Priority
            };

            var createdTask = await _taskService.CreateTaskAsync(task);

            var taskDto = new TaskDto
            {
                Id = createdTask.Id,
                ProjectId = createdTask.ProjectId,
                Title = createdTask.Title,
                Description = createdTask.Description,                
                Status = createdTask.Status,
                Priority = createdTask.Priority
            };

            return CreatedAtAction(nameof(GetTasks), new { projectId = taskDto.ProjectId }, taskDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "An internal server error occurred. Please try again later." });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto updateTaskDto, [FromQuery] string updatedBy)
    {
        if (updateTaskDto == null || id != updateTaskDto.Id)
        {
            return BadRequest(new { error = "Invalid task data." });
        }

        try
        {
            var task = new TaskEntity
            {
                Id = updateTaskDto.Id,
                Title = updateTaskDto.Title,
                Description = updateTaskDto.Description,                
                Status = updateTaskDto.Status
            };

            await _taskService.UpdateTaskAsync(task, updatedBy);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "An internal server error occurred. Please try again later." });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        try
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "An internal server error occurred. Please try again later." });
        }
    }
}
