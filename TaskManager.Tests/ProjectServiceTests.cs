using Moq;
using Xunit;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Service.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockRepo;
    private readonly Mock<ITaskRepository> _mockRepoTask;
    private readonly ProjectService _service;

    public ProjectServiceTests()
    {
        _mockRepo = new Mock<IProjectRepository>();
        _mockRepoTask = new Mock<ITaskRepository>();
        _service = new ProjectService(_mockRepo.Object, _mockRepoTask.Object);
    }

    [Fact]
    public async Task GetAllProjectsAsync_ShouldReturnAllProjects()
    {
        // Arrange
        var projects = new List<ProjectEntity> { new ProjectEntity { Id = 1, Name = "Test Project" } };
        _mockRepo.Setup(repo => repo.GetAllProjectsAsync()).ReturnsAsync(projects);

        // Act
        var result = await _service.GetAllProjectsAsync();

        // Assert
        Assert.Equal(projects, result);
    }   
}
