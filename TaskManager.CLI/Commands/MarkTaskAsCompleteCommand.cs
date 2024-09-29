using Spectre.Console.Cli;
using TaskManager.Core.Services;
using System.ComponentModel;
using System;
using System.Linq;

namespace TaskManager.CLI.Commands
{
    public class MarkTaskAsCompleteCommand : Command<MarkTaskAsCompleteCommand.Settings>
    {
        private readonly ITaskService _taskService;

        public MarkTaskAsCompleteCommand(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Settings class to handle command line arguments
        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<id>")]
            [Description("The ID of the task to mark as complete")]
            public Guid Id { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var task = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == settings.Id);

            if (task != null)
            {
                _taskService.MarkTaskAsComplete(settings.Id);
                Console.WriteLine($"Task '{task.Title}' has been marked as complete.");
            }
            else
            {
                Console.WriteLine("No task found with the specified ID.");
            }

            return 0;
        }
    }
}
