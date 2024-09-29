using Spectre.Console.Cli;
using TaskManager.Core.Services;
using System;
using System.Linq;
using System.ComponentModel;

namespace TaskManager.CLI.Commands
{
    public class DeleteTaskCommand : Command<DeleteTaskCommand.Settings>
    {
        private readonly ITaskService _taskService;

        public DeleteTaskCommand(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Command settings to accept input arguments
        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<id>")]
            [Description("The ID of the task to delete")]
            public Guid Id { get; set; } = Guid.Empty;
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            // Find the task with the specified ID
            var task = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == settings.Id);

            if (task != null)
            {
                // Delete the task if found
                _taskService.DeleteTask(task.Id);
                Console.WriteLine($"Task {task.Title} was deleted (ID: {task.Id})");
            }
            else
            {
                Console.WriteLine("No task with the specified ID was found");
            }
            return 0;
        }
    }
}
