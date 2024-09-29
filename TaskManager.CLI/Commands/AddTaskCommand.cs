using Spectre.Console.Cli;
using TaskManager.Core.Services;
using TaskManager.Core.Models;
using System.ComponentModel;
using System;

namespace TaskManager.CLI.Commands
{
    public class AddTaskCommand : Command<AddTaskCommand.Settings>
    {
        private readonly ITaskService _taskService;
        public AddTaskCommand(ITaskService taskservice)
        {
            _taskService = taskservice;
        }
        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<title>")]
            [Description("Specify the title of the task")]
            public string Title { get; set; } = string.Empty;
        }
        public override int Execute(CommandContext context, Settings settings)
        {
            var task = new TaskItem { Title = settings.Title };
            _taskService.AddTask(task);
            Console.WriteLine("Task has been added.");
            return 0;
        }
    }
}