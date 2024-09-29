using Spectre.Console.Cli;
using TaskManager.CLI.Commands;
using TaskManager.Core.Models;
using TaskManager.Core.Services;
using TaskManager.Core.Repositories;
using TaskManager.CLI.DependencyInjection;
using System.IO;

namespace TaskManager.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            var registrar = new TypeRegistrar();

            // Specify the path for the JSON file storage
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");

            // Register the JsonFileRepository instead of InMemoryRepository
            registrar.RegisterInstance<IRepository<TaskItem>>(new JsonFileRepository<TaskItem>(filePath));
            registrar.Register<ITaskService, TaskService>();

            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddTaskCommand>("add");
                config.AddCommand<ListTasksCommand>("list");
                config.AddCommand<DeleteTaskCommand>("delete");
                config.AddCommand<MarkTaskAsCompleteCommand>("complete");
            });

            return app.Run(args);
        }
    }
}
