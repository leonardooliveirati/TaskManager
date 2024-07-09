using Moq;
using Xunit;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Service.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepo;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _service = new TaskService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetTasksByProjectIdAsync_ShouldReturnTasks_WhenTasksExist()
    {
        // Arrange
        var tasks = new List<TaskEntity> { new TaskEntity { Id = 1, ProjectId = 1, Title = "Test Task" } };
        _mockRepo.Setup(repo => repo.GetTasksByProjectIdAsync(1)).ReturnsAsync(tasks);

        // Act
        var result = await _service.GetTasksByProjectIdAsync(1);

        // Assert
        Assert.Equal(tasks, result);
    }

    [Fact]
    public async Task CreateTaskAsync_ShouldAddTask()
    {
        // Arrange
        var task = new TaskEntity { Id = 1, ProjectId = 1, Title = "New Task" };
        _mockRepo.Setup(repo => repo.CreateTaskAsync(task)).ReturnsAsync(task);

        // Act
        var result = await _service.CreateTaskAsync(task);

        // Assert
        Assert.Equal(task, result);
    }    
}
