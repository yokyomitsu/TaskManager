using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;

namespace TaskManager.Core.Services
{
    public class TaskService : ITaskService
    {
        public readonly IRepository<TaskItem> _repository;
        public TaskService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TaskItem> GetAllTasks() => _repository.GetAll();
        public void AddTask(TaskItem task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return;
            }

            _repository.Add(task);
        }
        public void MarkTaskAsComplete(Guid id)
        {
            var task = _repository.GetAll().FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Status = TaskItem.TaskStatus.Complete;
                _repository.Update(task); // Ensure changes are saved
            }
        }

        public void DeleteTask(Guid id)
        {
            var task = _repository.GetAll().FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _repository.Remove(task);
            }
        }
    }
}