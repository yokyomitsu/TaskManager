using System;
using System.Runtime.CompilerServices;

namespace TaskManager.Core.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TaskStatus Status { get; set; } = TaskStatus.Incomplete;

        public TaskItem()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Status = TaskStatus.Incomplete;
        }
        public enum TaskStatus
        {
            Incomplete,
            Complete,
        }
    }
}