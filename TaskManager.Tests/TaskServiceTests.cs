using Xunit;
using TaskManager.Core.Services;
using TaskManager.Core.Models;
using TaskManager.Tests.TestUtilities;
using System;
using System.Linq;

namespace TaskManager.Tests
{
    public class TaskServiceTests
    {
        private readonly ITaskService _taskService;
        private readonly InMemoryTestRepository<TaskItem> _repository;

        public TaskServiceTests()
        {
            _repository = new InMemoryTestRepository<TaskItem>();
            _taskService = new TaskService(_repository);
        }

        [Fact]
        public void AddTask_ShouldAddTaskSuccessfully()
        {
            var task = new TaskItem { Title = "Test Task" };

            _taskService.AddTask(task);

            var allTasks = _taskService.GetAllTasks();
            Assert.Single(allTasks);
            Assert.Equal("Test Task", allTasks.First().Title);
        }

        [Fact]
        public void AddTask_WithNullTitle_ShouldNotAddTask()
        {
            var task = new TaskItem { Title = null };

            _taskService.AddTask(task);

            var allTasks = _taskService.GetAllTasks();
            Assert.Empty(allTasks); // Assuming the AddTask method doesn't add tasks with null titles
        }

        [Fact]
        public void AddTask_WithEmptyTitle_ShouldNotAddTask()
        {
            var task = new TaskItem { Title = "" };

            _taskService.AddTask(task);

            var allTasks = _taskService.GetAllTasks();
            Assert.Empty(allTasks); // Assuming the AddTask method doesn't add tasks with empty titles
        }

        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            var task1 = new TaskItem { Title = "Task 1" };
            var task2 = new TaskItem { Title = "Task 2" };
            _repository.Add(task1);
            _repository.Add(task2);

            var allTasks = _taskService.GetAllTasks();

            Assert.Equal(2, allTasks.Count());
        }

        [Fact]
        public void GetAllTasks_WhenNoTasksExist_ShouldReturnEmpty()
        {
            var allTasks = _taskService.GetAllTasks();
            Assert.Empty(allTasks);
        }

        [Fact]
        public void DeleteTask_ShouldRemoveTaskSuccessfully()
        {
            var task = new TaskItem { Title = "Task to be deleted" };
            _repository.Add(task);

            _taskService.DeleteTask(task.Id);

            var allTasks = _taskService.GetAllTasks();
            Assert.Empty(allTasks);
        }

        [Fact]
        public void DeleteTask_WithNonExistentID_ShouldDoNothing()
        {
            var task = new TaskItem { Title = "Task to be deleted" };
            _repository.Add(task);

            _taskService.DeleteTask(Guid.NewGuid()); // Attempt to delete a task with a random ID

            var allTasks = _taskService.GetAllTasks();
            Assert.Single(allTasks);
        }

        [Fact]
        public void DeleteTask_WithEmptyGuid_ShouldDoNothing()
        {
            var task = new TaskItem { Title = "Task to be deleted" };
            _repository.Add(task);

            _taskService.DeleteTask(Guid.Empty); // Attempt to delete a task with Guid.Empty

            var allTasks = _taskService.GetAllTasks();
            Assert.Single(allTasks);
        }

        [Fact]
        public void MarkTaskAsComplete_ShouldChangeTaskStatus()
        {
            var task = new TaskItem { Title = "Incomplete Task", Status = TaskItem.TaskStatus.Incomplete };
            _repository.Add(task);

            _taskService.MarkTaskAsComplete(task.Id);

            var updatedTask = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == task.Id);
            Assert.NotNull(updatedTask);
            Assert.Equal(TaskItem.TaskStatus.Complete, updatedTask.Status);
        }

        [Fact]
        public void MarkTaskAsComplete_WithNonExistentID_ShouldDoNothing()
        {
            var task = new TaskItem { Title = "Incomplete Task", Status = TaskItem.TaskStatus.Incomplete };
            _repository.Add(task);

            _taskService.MarkTaskAsComplete(Guid.NewGuid()); // Attempt to mark a non-existent task as complete

            var unchangedTask = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == task.Id);
            Assert.NotNull(unchangedTask);
            Assert.Equal(TaskItem.TaskStatus.Incomplete, unchangedTask.Status);
        }

        [Fact]
        public void MarkTaskAsComplete_WithEmptyGuid_ShouldDoNothing()
        {
            var task = new TaskItem { Title = "Incomplete Task", Status = TaskItem.TaskStatus.Incomplete };
            _repository.Add(task);

            _taskService.MarkTaskAsComplete(Guid.Empty); // Attempt to mark a task with Guid.Empty as complete

            var unchangedTask = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == task.Id);
            Assert.NotNull(unchangedTask);
            Assert.Equal(TaskItem.TaskStatus.Incomplete, unchangedTask.Status);
        }
    }
}
