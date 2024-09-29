using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TaskManager.Core.Models;

namespace TaskManager.Core.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAllTasks();
        void AddTask(TaskItem task);
        void MarkTaskAsComplete(Guid id);
        void DeleteTask(Guid id);   
    }
}