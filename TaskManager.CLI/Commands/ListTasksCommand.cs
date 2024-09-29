// Commands/ListTasksCommand.cs
using Spectre.Console.Cli;
using TaskManager.Core.Services;
using Spectre.Console;
using System.Linq;

namespace TaskManager.CLI.Commands
{
    public class ListTasksCommand : Command<ListTasksCommand.Settings>
    {
        private readonly ITaskService _taskService;

        public ListTasksCommand(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public class Settings : CommandSettings
        {
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var tasks = _taskService.GetAllTasks();
            
            if (tasks.Any())
            {
                var table = new Table();
                table.AddColumn("ID");
                table.AddColumn("Title");
                table.AddColumn("Status");

                foreach (var task in tasks)
                {
                    // Ensure no null values are passed to AddRow
                    table.AddRow(
                        task.Id.ToString() ?? "N/A",
                        task.Title ?? "No Title",
                        task.Status.ToString() ?? "Unknown"
                    );
                }

                AnsiConsole.Write(table);
            }
            else
            {
                Console.WriteLine("タスクがありません");
            }
            
            return 0;
        }
    }
}
